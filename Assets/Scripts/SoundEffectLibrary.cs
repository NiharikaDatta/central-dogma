using System.Collections.Generic;
using UnityEngine;

public class SoundEffectLibrary : MonoBehaviour
{
    [SerializeField] SoundEntry[] soundEntries; //setting it as array so visible in unity's inspector. here, SoundEntry is the VARIABLE. this is the struct we are talking about...
    private Dictionary<string, List<AudioClip>> soundDictionary; //the key is the string and we use list cus we don't know the length of the number of audio clips!! here, we are INITIALISING!!! like, public int[] numbers
    void Awake() //awake is better than start cus it happens BEFORE start running even if object disabled. 
    {
        InitializeDict(); //remember unity cannot handle dictionaries in the inspector....so need to convert to array for humans and then to dictionary for code....
    }
    private void InitializeDict()
    {
        soundDictionary = new Dictionary<string, List<AudioClip>>(); //here, we are taking that same soundDictionary and DECLARING!!! like, numbers=new int[5]
        foreach (SoundEntry sound in soundEntries) //SoundEntry is a variable - the struct at the bottom!!! sound is what we are calling it temporarily. soundEntries is the NAME of the array SerializeField at top!!! structure: foreach(var name in collection)
        {
            soundDictionary[sound.name] = sound.audioClips;
        }
    }
    public AudioClip RandomaudioClip(string name) //gets a name as an input to check against
    {
        if(soundDictionary.ContainsKey(name)) //checks if that name exists
        {
            List<AudioClip> audioClips = soundDictionary[name]; //gets all audios with that name attached to them
            if(audioClips.Count>0)
            {
                return audioClips[Random.Range(0, audioClips.Count)]; //returns an audioclip randomly
            }
        }
        return null; //if something goes wrong, doesn't throw an error (thank god!!!)
    }

}
//okay so SoundEntry is a box. this box has a nametage and a bucket of audioclips. when we are making it an array, we are making an array of BOXES...all those boxes contain a nametag and a bucket of audioclips....like, soundEntries[0] = [name: "Zoom"; audioClips: {zoom1.mp3, zoom2.mp3}]....capiche!?!?
[System.Serializable] //so we can serialisefield it as an array of type SoundEntry...
public struct SoundEntry //struct bc it is simple data taking. no methods or functions. so struct is better cus lightweight
{
    public string name; //the nametag
    public List<AudioClip> audioClips; //the bucket of audioclips
}