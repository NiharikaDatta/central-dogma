using System.Collections.Generic;
using UnityEngine;

public class StrandManager : MonoBehaviour
{

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
            if(strandLibrary==null)
            {
                Debug.Log("Strand library not found!!!");
            }
            else
            {
                Debug.Log("Strand Library successfully found!!!");
            }
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
}
