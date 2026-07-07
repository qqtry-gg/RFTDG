using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("AudioClip")]
    public AudioClip gameBackground;
    public AudioClip menuBackground;
    public AudioClip buttonPressed;
    public AudioClip lose;
    public AudioClip waveCompleted;
    public AudioClip enemyDeath;
    public AudioClip archerTowerAttack;
    public AudioClip poisonTowerAttack;
    public AudioClip groundbreakerTowerAttack;
    public AudioClip freezeTowerAttack;
    public AudioClip Explosion;

    public static AudioManager instance;

    bool soundplayed = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeMusic(SceneManager.GetActiveScene().buildIndex);


    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void PlaySFXOnce(AudioClip clip) //Plays the sound only once per scene
    {
        if (soundplayed == false)
        {
            SFXSource.PlayOneShot(clip);
            soundplayed = true;
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ChangeMusic(scene.buildIndex);
    }
    private void ChangeMusic(int buildIndex)
    {
        AudioClip newClip;

        if (buildIndex == 4)
        {
            newClip = gameBackground;
        }
        else
        {
            newClip = menuBackground;
        }
        if (musicSource.clip == newClip)
        {
            return;
        }
        musicSource.clip = newClip;
        musicSource.Play();
    }
}
