using UnityEngine;

[CreateAssetMenu(fileName = "NucleotideData", menuName = "Scriptable Objects/New Nucleotide")]
public class NucleotideData : ScriptableObject
{
    public enum NucleotideType {A, U, G, C, T};
    public NucleotideType nucleotideType;
    public string displayName;
    public string pickupSound;
    public float minPitch = 0.5f;
    public float maxPitch=1.5f;
    public NucleotideType pairsWith;
    public Sprite sprite;
    public Color normalColor = Color.white;
    public Color matchedColor = Color.antiqueWhite;
}
