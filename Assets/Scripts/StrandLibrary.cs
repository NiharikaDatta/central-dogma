using System.Collections.Generic;
using UnityEngine;

public class StrandLibrary : MonoBehaviour
{
    public StrandData[] allStrands;
    private static Dictionary<string, StrandData> strandDictionary;
    void Awake()
    {
        InitializeDict();
    }
  void InitializeDict()
    {
        strandDictionary = new Dictionary<string, StrandData>();
        foreach(StrandData strands in allStrands)
        {
            if(!strandDictionary.ContainsKey(strands.name))
            {
                strandDictionary.Add(strands.name, strands);
            }
            else
            {
                Debug.LogWarning("A duplicate strand!! Check?");
            }
        }
    }
    public StrandData getStrand(string name)
    {
        if(strandDictionary.ContainsKey(name))
        {
            return strandDictionary[name];
        }
        else
        {
            Debug.LogWarning("Doesn't exist. try different spelling?");
            return null;
        }
    }
}