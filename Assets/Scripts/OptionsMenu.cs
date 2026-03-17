using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    private int resolutionIndex=0;
    public void ApplyMusicVolume(float volume)
    {
        SoundEffectManager.Instance.SetMusicVolume(volume);
    }
    public void ApplySFXVolume(float volume)
    {
        SoundEffectManager.Instance.SetSFXVolume(volume);
    }
    public void GraphicsQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }
    public void FullScreen(bool isFullScreen)
    {
        Screen.fullScreen=isFullScreen;
    }
    void Start()
    {
        resolutions=Screen.resolutions;
        List<string> options=new List<string>();
        for(int i=0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option); //adding the string to the actual list cus can't add to list directly...
            if(resolutions[i].width==Screen.width && 
            resolutions[i].height==Screen.height)
            {
                resolutionIndex=i;
            }
        }
        resolutionDropdown.ClearOptions(); //cus we have placeholder values we don't actually need...
        resolutionDropdown.AddOptions(options); //will only take list of type string...
        resolutionDropdown.value=resolutionIndex;
        resolutionDropdown.RefreshShownValue(); //to actually show it...
    }
}
