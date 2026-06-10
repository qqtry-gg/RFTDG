using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    [SerializeField] GameObject gamePausedUI;

    public void ExitTheGame()
    {
        
        Application.Quit();
    }
    public void CreditsScene()
    {
        SceneManager.LoadScene(1);
    }
    public void PlayScene()
    {
        SceneManager.LoadScene(2);
    }
    public void SettingsScene()
    {
        SceneManager.LoadScene(3);
    }
    public void EndlessPlay()
    {
        SceneManager.LoadScene(4);
    }
    public void BackScene()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenGamePausedUI()
    {
        gamePausedUI.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("Pause");
    }
    public void CloseGamePausedUI()
    {
        gamePausedUI.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("UnPause");
    }

}
