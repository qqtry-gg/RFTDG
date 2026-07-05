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



    bool soundplayed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            musicSource.clip = gameBackground;
        }
        else
        {
            musicSource.clip = menuBackground;
        }
        musicSource.Play();
        musicSource.loop = true;
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
}
