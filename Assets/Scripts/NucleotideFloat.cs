using UnityEngine;

public class NucleotideFloat : MonoBehaviour
{
    NucleotideData floatingData;
    void Start()
    {
        GetComponent<SpriteRenderer>().color = floatingData.normalColor;
        GetComponent<SpriteRenderer>().sprite = floatingData.sprite;
    }
}
