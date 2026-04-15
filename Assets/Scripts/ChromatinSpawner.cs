using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class ChromatinSpawner : MonoBehaviour
{
    [SerializeField] private int NumberofStrands=3;
    [SerializeField] private GameObject chromatin;
    [SerializeField] private float spawnrange=8.3f;
    [SerializeField] private float spawnlength=4.2f;
    public static StrandLibrary strandLibrary;
    private GameObject strand;
    [SerializeField] private GameObject strandmanager;
    void Start()
    {
        strandLibrary=strandmanager.GetComponent<StrandLibrary>();
        SpawnChromatin();
    }
    private void SpawnChromatin()
    {
        List<StrandData> randomStrands=getRandomStrand(NumberofStrands);
        for(int i=0; i<NumberofStrands; i++)
        {
            Vector3 position=new Vector3(Random.Range(-spawnrange,spawnrange), Random.Range(-spawnlength, spawnlength), 0);
            strand = Instantiate(chromatin, position, Quaternion.identity);
            strand.GetComponent<Chromatin>().strandData=randomStrands[i];
        }
    }
    private List<StrandData> getRandomStrand(int count)
    {
        List<StrandData> result=new List<StrandData>();
        List<StrandData> available=new List<StrandData>(strandLibrary.allStrands);
        for(int i=0; i<count && available.Count>0; i++)
        {
            StrandData selected=GetWeightedRandom(available);
            result.Add(selected);
            available.Remove(selected);
        }
        return result;
    }
    private StrandData GetWeightedRandom(List<StrandData> dataList)
    {
        float totalweight=0f;
        foreach(StrandData data in dataList)
        {
            totalweight+=data.rarity;
        }
        float random=Random.Range(0, totalweight);
        float current=0f;
        foreach(StrandData strand in dataList)
        {
            current+=strand.rarity;
            if(random<=current)
            {
                return strand;
            }
        }            
        return dataList[0];   
    }     
}