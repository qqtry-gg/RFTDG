using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelChosen : MonoBehaviour
{
    [Header("InfoAboutTheLevel")]
    [SerializeField] string levelName;
    [SerializeField] string numberOfWaves;
    [SerializeField] string rewardsAmount;
    [SerializeField] string description;
    [SerializeField] Sprite mapPreview;
    [SerializeField] levelDifficultyenum currentLevelDifficulty;
    [SerializeField] levelType currentLevelType;



    enum levelDifficultyenum
    {
        Skirmish,
        Raid,
        Assault,
        Siege,
        Invasion,
        Conquest,
        Cataclysm,
        Annihilation,
        Apocalypse,
        Oblivion
    }
    enum levelType
    {
        Grass,
        Ice,
        Fire,
        Rock,
        Death
    }
    TextMeshProUGUI levelDifficultyText;
    TextMeshProUGUI levelTypeText;
    bool isSelected = false;
    static LevelChosen selectedLevel;
    ButtonClick buttonClickSound;
    Animator animator;
    Animator anim;


    GameObject levelMenuContainer;
    GameObject LevelMenu;
    GameObject mapPreviewUI;
    GameObject levelNameUI;
    GameObject levelDifficultyUI;
    GameObject levelTypeUI;
    GameObject numberOfWavesUI;
    GameObject amountOfRewardUI;
    GameObject levelDescriptionUI;
    private void Update()
    {
        if (currentLevelDifficulty == levelDifficultyenum.Oblivion && levelDifficultyText != null && selectedLevel == this)
        {
            float pulse = Mathf.PingPong(Time.time * 1.5f, 1);

            Color color = Color.Lerp(Color.black, new Color(0.5f,0,1f), pulse);

            levelDifficultyText.color = color;

            Material mat = levelDifficultyText.material;

            mat.EnableKeyword("UNDERLAY_ON");

            mat.SetColor(ShaderUtilities.ID_UnderlayColor, new Color(0.5f,0,1,0.8f));

            mat.SetFloat(ShaderUtilities.ID_UnderlayDilate, 0.5f);

            mat.SetFloat(ShaderUtilities.ID_UnderlaySoftness, 0.5f);
        }
    }
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        buttonClickSound = FindFirstObjectByType<ButtonClick>();


        LevelMenu = GameObject.FindGameObjectWithTag("LevelMenu");
        mapPreviewUI = GameObject.FindGameObjectWithTag("mapPreview");
        levelNameUI = GameObject.FindGameObjectWithTag("levelName");
        levelDifficultyUI = GameObject.FindGameObjectWithTag("LevelDifficulty");
        levelTypeUI = GameObject.FindGameObjectWithTag("levelType");
        numberOfWavesUI = GameObject.FindGameObjectWithTag("waves");
        amountOfRewardUI = GameObject.FindGameObjectWithTag("gemsAmount");
        levelDescriptionUI = GameObject.FindGameObjectWithTag("Description");

    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (selectedLevel != null)
        {
            selectedLevel.StopGlow();
        }
        buttonClickSound.ButtonsPressed();
        LevelMenu.GetComponentInChildren<MenuAnimationScript>().OpenMenu();

        selectedLevel = this;

        
        SetLevelData();
    }
    void SetLevelData()
    {
        levelDifficultyText = levelDifficultyUI.GetComponent<TextMeshProUGUI>();

        ResetDifficultyGlow();
        levelNameUI.GetComponent<TextMeshProUGUI>().text = "Level Name: " + levelName;
        levelDifficultyText.text = "Difficulty: " + currentLevelDifficulty;
        levelTypeText = levelTypeUI.GetComponent<TextMeshProUGUI>();
        levelTypeText.text = "Type: " + currentLevelType;
        numberOfWavesUI.GetComponent<TextMeshProUGUI>().text = "Waves: " + numberOfWaves;
        amountOfRewardUI.GetComponent<TextMeshProUGUI>().text = rewardsAmount;
        levelDescriptionUI.GetComponent<TextMeshProUGUI>().text = "Description: " + description;
        mapPreviewUI.GetComponent<Image>().sprite = mapPreview;
        switch (currentLevelDifficulty)
        {
            case levelDifficultyenum.Skirmish:
                levelDifficultyText.color = Color.lightGreen;
                break;
            case levelDifficultyenum.Raid:
                levelDifficultyText.color = Color.green;
                break;
            case levelDifficultyenum.Assault:
                levelDifficultyText.color = Color.darkGreen;
                break;
            case levelDifficultyenum.Siege:
                levelDifficultyText.color = Color.yellow;
                break;
            case levelDifficultyenum.Invasion:
                levelDifficultyText.color = Color.orange;
                break;
            case levelDifficultyenum.Conquest:
                levelDifficultyText.color = Color.orangeRed;
                break;
            case levelDifficultyenum.Cataclysm:
                levelDifficultyText.color = Color.red;
                break;
            case levelDifficultyenum.Annihilation:
                levelDifficultyText.color = Color.darkRed;
                break;
            case levelDifficultyenum.Apocalypse:
                levelDifficultyText.color = Color.purple;
                break;
            case levelDifficultyenum.Oblivion:
                levelDifficultyText.color = Color.Lerp(Color.black, new Color(0.4f,0,0.6f), Mathf.PingPong(Time.time, 1));
                break;
        }
        switch (currentLevelType)
        {
            case levelType.Ice:
                levelTypeText.color = Color.lightBlue;
                break;
            case levelType.Fire:
                levelTypeText.color = Color.red;
                break;
            case levelType.Rock:
                levelTypeText.color = Color.gray;
                break;
            case levelType.Grass:
                levelTypeText.color = Color.green;
                break;
            case levelType.Death:
                levelTypeText.color = Color.black;
                break;
        }
    }
    void ResetDifficultyGlow()
    {
        Material mat = levelDifficultyText.fontMaterial;

        mat.DisableKeyword("UNDERLAY_ON");

        mat.SetColor(ShaderUtilities.ID_UnderlayColor, Color.clear);

        mat.SetFloat(ShaderUtilities.ID_UnderlayDilate, 0);

        mat.SetFloat(ShaderUtilities.ID_UnderlaySoftness, 0);
    }
    void StopGlow()
    {
        ResetDifficultyGlow();
    }
    private void OnMouseEnter()
    {
        animator.SetTrigger("HoverOver");
    }
}
