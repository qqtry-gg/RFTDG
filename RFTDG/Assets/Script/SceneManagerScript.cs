using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
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

}
