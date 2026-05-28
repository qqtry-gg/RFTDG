using TMPro;
using UnityEngine;

public class EndlessModeManager : MonoBehaviour
{
    [SerializeField] GameManagerScript gameManagerScript;
    [SerializeField] RNDSpawning RNDSpawning;
    [SerializeField] GameObject waveTMP;
    int wave = 0;
    [SerializeField] int cashIncreaseEarning = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wave++;
        waveTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Wave: " + wave;
        gameManagerScript.cash = 20;
        gameManagerScript.health = 1;
        RNDSpawning.SpawnTower();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.health <= 0)
        {
            
            gameManagerScript.cash = 0;
            wave++;
            waveTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Wave: " + wave;
            RNDSpawning.SpawnTower();
            gameManagerScript.cash = 20 + (cashIncreaseEarning * wave);
            gameManagerScript.health++;
        }
        if (gameManagerScript.cash < 2)
        {
            Debug.Log("You lost");
        }
    }
}
