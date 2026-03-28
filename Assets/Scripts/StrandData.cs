using System;
using System.IO.Enumeration;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "StrandData", menuName = "Scriptable Objects/Strand")]
public class StrandData : ScriptableObject
{
    public string proteinName; //the funny name - like, oxygen carrier!!
    [TextArea]
    public string description;
    [TextArea] //will give us a bigger and more scrollable area to work with!!!!
    public string dnasequence; //massive!!!!
    public float rarity; //goes from 0.1 (most rare) to 1.0 (least rare)....not for mvp!!
    public string funfact; //the fun fact at the end?? a one-liner which will also go on their "trophy shelf"??
}