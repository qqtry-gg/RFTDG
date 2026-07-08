using UnityEngine;
using UnityEngine.UI;

public class FullScreenSettings : MonoBehaviour
{
    [SerializeField] Toggle ToggleFullScreen;
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        if (isFullScreen)
        {
            PlayerPrefs.SetInt("fullScreen", 1);
        }
        else if (!isFullScreen)
        {
            PlayerPrefs.SetInt("fullScreen", 0);
        }
    }
    private void Start()
    {
        LoadFullScreen();
    }
    void LoadFullScreen()
    {
        if (PlayerPrefs.HasKey("fullScreen"))
        {
            if (PlayerPrefs.GetInt("fullScreen") == 1) Screen.fullScreen = true;
            else if (PlayerPrefs.GetInt("fullScreen") == 0) Screen.fullScreen = false;
            ToggleFullScreen.isOn = Screen.fullScreen;
        }
    }
        
    }

