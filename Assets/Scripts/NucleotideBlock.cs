using UnityEngine;

public class NucleotideBlock : MonoBehaviour
{
    public NucleotideData data;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = data.normalColor;
        GetComponent<SpriteRenderer>().sprite = data.sprite;
    }
    public bool isMatched(NucleotideData floatingNucleotide)
    {
        return data.pairsWith==floatingNucleotide.nucleotideType;
    }
}
