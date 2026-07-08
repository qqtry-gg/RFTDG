using UnityEngine;

public class GraphicSettings : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Dropdown DropdownGraphicSetting;
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
            int qualityLevel = PlayerPrefs.GetInt("qualityLevel");
            QualitySettings.SetQualityLevel(qualityLevel);
            DropdownGraphicSetting.value = qualityLevel;
        }
    }
}
