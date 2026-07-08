using UnityEngine;

public class GraphicSettings : MonoBehaviour
{
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityLevel", qualityIndex);
    }
    private void Start()
    {
        LoadQualitySettings();
    }
    void LoadQualitySettings()
    {
        if (PlayerPrefs.HasKey("qualityLevel"))
        {
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("qualityLevel"));
        }
    }
}
