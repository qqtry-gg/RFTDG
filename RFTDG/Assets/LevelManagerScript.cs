using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    private int selectedLevel = -1;

    public void SetSelectedLevel(int level)
    {
        selectedLevel = level;
    }

    public void StartSelectedLevel()
    {
        if (selectedLevel == -1)
        {
            return;
        }
        SceneManager.LoadScene(5 + selectedLevel);
    }
}
