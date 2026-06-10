using NUnit.Framework;
using TMPro;
using UnityEngine;

public class EndlessModeManager : MonoBehaviour
{
    [SerializeField] UnlockNewTower unlockNewTower;
    [SerializeField] GameManagerScript gameManagerScript;
    [SerializeField] RNDSpawning RNDSpawning;
    [SerializeField] GameObject waveTMP;
    public int wave;
    [SerializeField] int cashIncreaseEarning = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wave = 1;
        waveTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Wave: " + wave;
        PlayWaveAnimation();
        gameManagerScript.cash = 30;
        gameManagerScript.health = 1;
        RNDSpawning.SpawnBadTower();
    }

    // Update is called once per frame
    void Update()
    {
        if (wave <= 200)
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
                        gameManagerScript.cooldown = 0;
                    }
                    Debug.Log("You won this round");
                }
                gameManagerScript.cash = 0;
                wave++;
                unlockNewTower.isChecked = false;
                waveTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Wave: " + wave;
                PlayWaveAnimation();
                if (!(wave >= 196))
                {
                    if (wave >= 20 && wave % 5 == 0)
                    {
                        RNDSpawning.SpawnSpike();

                    }
                    else
                    {
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
                    }
                }


                if (wave >= 150)
                {
                    cashIncreaseEarning += 100;
                }
                else if (wave >= 100)
                {
                    cashIncreaseEarning += 70;
                }
                else if (wave >= 40)
                {
                    cashIncreaseEarning += 50;
                }
                else if (wave >= 25)
                {
                    cashIncreaseEarning += 30;
                }
                else if (wave >= 10)
                {
                    cashIncreaseEarning += 20;
                }
                else
                {
                    cashIncreaseEarning += 10;
                }
                gameManagerScript.cash = 30 + cashIncreaseEarning;
                gameManagerScript.health = 1;
                if (wave >= 196)
                {
                    gameManagerScript.cash = 30 + (cashIncreaseEarning * wave) - wave * 20;
                }
            }
        }
        else
        {
            Debug.Log("You won the game!");
        }
        if (gameManagerScript.cash < 2 && gameManagerScript.enemies.Count == 1)
        {
            Debug.Log("You lost");
        }
    }
    void PlayWaveAnimation()
    {
        waveTMP.SetActive(true);
        waveTMP.GetComponent<Animator>().SetTrigger("WaveOver");
    }

}
