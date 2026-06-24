using UnityEngine;

public class BossSpawned : MonoBehaviour
{
    GameManagerScript managerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        managerScript = FindAnyObjectByType<GameManagerScript>();
        if (managerScript != null)
        {
            managerScript.AddBoss();
        }
    }
}
