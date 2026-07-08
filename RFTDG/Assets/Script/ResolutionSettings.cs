
using UnityEngine;

using System.Collections.Generic;
using TMPro;

public class ResolutionSettings : MonoBehaviour
{
    
    [SerializeField] TMP_Dropdown resolutionDropDown;
    Resolution[] resolutions; 
    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
        if (PlayerPrefs.HasKey("resolutionIndex"))
        {
            int ResolutionIndex = PlayerPrefs.GetInt("resolutionIndex");
            Screen.SetResolution(resolutions[ResolutionIndex].width, resolutions[ResolutionIndex].height, Screen.fullScreen);
            resolutionDropDown.value = ResolutionIndex;
        }
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        PlayerPrefs.SetInt("resolutionIndex", resolutionIndex);
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
}
