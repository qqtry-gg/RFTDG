using NUnit.Framework;
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
        gameManagerScript.cash = 30;
        gameManagerScript.health = 1;
        RNDSpawning.SpawnBadTower();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.health <= 0)
        {
            foreach (GameObject enemy in gameManagerScript.enemies)
            {
                if (enemy == null)
                { continue; }
                else
                {
                    Destroy(enemy.gameObject);
                }
                Debug.Log("You won this round");
            }
            gameManagerScript.cash = 0;
            wave++;
            waveTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Wave: " + wave;
            if (wave <= 10)
            {
                RNDSpawning.SpawnBadTower();
            }
            else if (wave <= 40)
            {
                RNDSpawning.SpawnMediumTower();
            }
            else
            {
                RNDSpawning.SpawnGoodTower();
            }


            if (wave >= 125)
            {
                cashIncreaseEarning = 100;
            }
            else if (wave >= 100)
            {
                cashIncreaseEarning = 70;
            }
            else if (wave >= 40)
            {
                cashIncreaseEarning = 50;
            }
            else if (wave >= 15)
            {
                cashIncreaseEarning = 30;
            }
            else if (wave >= 5)
            {
                cashIncreaseEarning = 20;
            }
            else
            {
                cashIncreaseEarning = 10;
            }
            gameManagerScript.cash = 30 + (cashIncreaseEarning * wave);
            gameManagerScript.health = 1;
        }
        if (gameManagerScript.cash < 2 && gameManagerScript.enemies.Count == 1)
        {
            Debug.Log("You lost");
        }
    }
}
