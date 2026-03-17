using UnityEngine;
using UnityEngine.Rendering;

public class SoundEffectManager : MonoBehaviour
{
    public static SoundEffectManager Instance; //creates an INSTANCE which is important especially for multiple scenes...
    private static AudioSource audioSource; //INITIALISE the audiosource which will run on unity
    private static AudioSource musicSource; //for the background music
    private static SoundEffectLibrary soundEffectLibrary; //INITIALISE the library object
    public AudioClip musicClip;
    void Awake()
    {
        if(Instance==null) //SINGLETON CODE!!!!! LEARNT IT TWENTY MINUTES AGO SO NOW I KNOW EVERYTHING ABOUT IT!!!! :')
        {
            Instance=this; //if there is no instance, this is THE instance
            AudioSource[] audioSources = GetComponents<AudioSource>();
            audioSource = audioSources[0]; //this one for sfx
            musicSource = audioSources[1]; //this one for backgroundmusic....
            soundEffectLibrary=GetComponent<SoundEffectLibrary>(); //get the library script as an object named soundEffectLibrary
            DontDestroyOnLoad(gameObject); //will not be destroyed in future scenes
        }
        else
        {
            Destroy(gameObject); //if THE instance already exists, delete THIS instance out of existence....
        }
    }
    public static void Play(string soundName) //the method we will call from practically all our scripts...static cus can't be bothered with the hassle of objects and shit all the time i want to play the Play(name)....
    {
        AudioClip audioClip = soundEffectLibrary.RandomaudioClip(soundName); //remember RandomaudioClip?? yeah...this will run that and return the audioclip....
        if(audioClip!=null) //error handling. no need for else cus this is a void method
        {
            audioSource.PlayOneShot(audioClip); //plays only once. (i need better names for shit....i have like, four audioClip variables in as many methods.......) PlayOneShot is an INSTANCE method and can be called via the variable of the class...
        }
        //todos:-
        //wtf is playclipatpoint!?!!? - done!!
        //another audiosource for background, i think....
    }
    public static void PlayAtPosition(string soundName, Vector3 position) //in case i want to...
    {
        AudioClip audioClip = soundEffectLibrary.RandomaudioClip(soundName); //oh no, saw audioclips too many times...it's starting to look weird....
        if(audioClip!=null)
        {
            AudioSource.PlayClipAtPoint(audioClip, position); //PlayClipAtPoint is a STATIC method and needs the class name instead of an instance variable of it!!!! fucking java and FUCKING OOP PROGRAMMING!!!! >:(
        }
    }
    //following all are for background music....
    public void PlayBackgroundMusic()
    {
        if(musicClip!=null) //error handling!!
        {
            musicSource.clip = musicClip; //assigns the clip to the audiosource
            musicSource.Play();
            musicSource.loop=true;
        }
    }
    public void PauseBackgroundMusic()
    {
        musicSource.Pause();
    }
    public void ResumeBackgroundMusic()
    {
        musicSource.UnPause();
    }
    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }
    void Start() //bc i want to start it as soon as i boot it up....
    {
        if(musicClip!=null)
        {
            PlayBackgroundMusic();
        }
    }
    //following for the sliders and stuff....
    public void SetSFXVolume(float volume)
    {
        if(audioSource!=null)
        {
            audioSource.volume=volume;
        }
    }
    public void SetMusicVolume(float volume)
    {
        if(musicSource!=null)
        {
            musicSource.volume=volume;
        }
    }
}