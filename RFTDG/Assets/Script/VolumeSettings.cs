using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer Mixer;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider SFXSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else SetMusicVolume();
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadSFX();
        }
        else SetSFXVolume();
    }
    public void SetMusicVolume()
    {
        if (musicSlider != null)
        {
            float volume = musicSlider.value;
            Mixer.SetFloat("music", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }

    }
    public void SetSFXVolume()
    {
        if (SFXSlider != null)
        {
            float volume = SFXSlider.value;
            Mixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("SFXVolume", volume);
        }

    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        Mixer.SetFloat("music", Mathf.Log10(PlayerPrefs.GetFloat("musicVolume")) * 20);

        SetMusicVolume();
    }
    private void LoadSFX()
    {
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        Mixer.SetFloat("SFX", Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume")) * 20);

        SetSFXVolume();
    }
}
