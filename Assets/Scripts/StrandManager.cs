using System.Collections.Generic;
using UnityEngine;

public class StrandManager : MonoBehaviour
{
    public GameObject blockPrefab;
    public NucleotideData adenine;
    public NucleotideData thymine;
    public NucleotideData cytosine;
    public NucleotideData guanine;

    [SerializeField] private float blockspacing=1.5f;

    public static StrandManager Instance;
    public static StrandLibrary strandLibrary;
    public static StrandData currentStrand;
    void Awake()
    {
        if(Instance==null)
        {
            Instance=this;
            strandLibrary = GetComponent<StrandLibrary>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static void Strand(string strandName)
    {
        currentStrand = strandLibrary.getStrand(strandName);
    }
    void Start()
    {
        //CreateStrand();
    }
    void CreateStrand()
    {
        for(int i = 0; i<currentStrand.dnasequence.Length; i++)
        {
            char nucleotide = currentStrand.dnasequence[i];
            NucleotideData data = getDataforLetter(nucleotide);
            Vector3 position = new Vector3(i*blockspacing, 0, 0);
            GameObject newNucleotide = Instantiate(blockPrefab, position, Quaternion.identity);
            newNucleotide.GetComponent<NucleotideBlock>().data = data;
            newNucleotide.name = "Block_" + data.nucleotideType + "_" + i;
        }
    }
    NucleotideData getDataforLetter(char letter)
    {
        switch(letter)
        {
            case 'A': return adenine;
            case 'T': return thymine;
            case 'C': return cytosine;
            case 'G': return guanine;
            default: return null;
        }
    }
}
