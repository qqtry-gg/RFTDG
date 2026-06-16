using JetBrains.Annotations;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class EndlessModeManager : MonoBehaviour
{
    [SerializeField] UnlockNewTower unlockNewTower;
    [SerializeField] GameManagerScript gameManagerScript;
    [SerializeField] RNDSpawning RNDSpawning;
    [SerializeField] GameObject waveTMP;
    [SerializeField] GameObject youWonUI;
    [SerializeField] GameObject youLostUI;
    public int wave;
    [SerializeField] int cashIncreaseEarning = 0;
    public enum ElementMap
    {
        Normal,
        Fire,
        Ice,
        Grass,
        Sand,
        Rock,
        Death
    }
    public ElementMap currentElementMap = ElementMap.Normal;
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
                if (wave % 10 == 0)
                {
                    ElementMap[] allElements = (ElementMap[])System.Enum.GetValues(typeof(ElementMap));

                    currentElementMap = allElements[Random.Range(0, allElements.Length)];
                }
            }
        }
        else
        {
            youWonUI.SetActive(true);
        }
        gameManagerScript.enemies.RemoveAll(enemy => enemy == null);
        if (gameManagerScript.cash <= 0 && gameManagerScript.enemies.Count == 0)
        {
            youLostUI.SetActive(true);
        }
    }
    void PlayWaveAnimation()
    {
        waveTMP.SetActive(true);
        waveTMP.GetComponent<Animator>().SetTrigger("WaveOver");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthScript>() != null && collision.gameObject.GetComponent<HealthScript>().isBossted == false)
        {
            HealthScript currentEnemyHealthScript = collision.gameObject.GetComponent<HealthScript>();
            EnemyMovementScript currentEnemyMovementScript = collision.gameObject.GetComponent<EnemyMovementScript>();
            if (currentElementMap == ElementMap.Death )
            {
                if (currentEnemyHealthScript.enemyType == HealthScript.Type.Death)
                {
                    SuperEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Grass)
                {
                    WorstEffective();
                }
            }
            if (currentElementMap == ElementMap.Grass)
            {
                if (currentEnemyHealthScript.enemyType == HealthScript.Type.Grass)
                {
                    SuperEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Sand)
                {
                    Effective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Ice)
                {
                    NotEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Rock)
                {
                    NotEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Fire)
                {
                    WorstEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Death)
                {
                    WorstEffective();
                }
            }
            if (currentElementMap == ElementMap.Fire)
            {
                if (currentEnemyHealthScript.enemyType == HealthScript.Type.Fire)
                {
                    SuperEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Sand)
                {
                    Effective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Grass)
                {
                    WorstEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Ice)
                {
                    WorstEffective();
                }
            }
            if (currentElementMap == ElementMap.Ice)
            {
                if (currentEnemyHealthScript.enemyType == HealthScript.Type.Ice)
                {
                    SuperEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Rock)
                {
                    Effective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Sand)
                {
                    NotEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Fire)
                {
                    WorstEffective();
                }
            }
            if (currentElementMap == ElementMap.Sand)
            {
                if (currentEnemyHealthScript.enemyType == HealthScript.Type.Sand)
                {
                    SuperEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Fire)
                {
                    Effective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Rock)
                {
                    Effective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Grass)
                {
                    Effective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Ice)
                {
                    WorstEffective();
                }
            }
            if (currentElementMap == ElementMap.Rock)
            {
                if (currentEnemyHealthScript.enemyType == HealthScript.Type.Rock)
                {
                    SuperEffective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Sand)
                {
                    Effective();
                }
                else if (currentEnemyHealthScript.enemyType == HealthScript.Type.Grass)
                {
                    NotEffective();
                }
            }
            void SuperEffective()
            {
                currentEnemyHealthScript.hitpoints *= 1.4f;
                currentEnemyHealthScript.maxHealth *= 1.4f;
                currentEnemyMovementScript.movespeed *= 1.2f;
                currentEnemyMovementScript.normalspeed *= 1.2f;
                currentEnemyHealthScript.isBossted = true;
            }
            void Effective()
            {
                currentEnemyHealthScript.hitpoints *= 1.2f;
                currentEnemyHealthScript.maxHealth *= 1.2f;
                currentEnemyMovementScript.movespeed *= 1.1f;
                currentEnemyMovementScript.normalspeed *= 1.1f;
                currentEnemyHealthScript.isBossted = true;
            }
            void NotEffective()
            {
                currentEnemyHealthScript.hitpoints *= 0.8f;
                currentEnemyHealthScript.maxHealth *= 0.8f;
                currentEnemyMovementScript.movespeed *= 0.9f;
                currentEnemyMovementScript.normalspeed *= 0.9f;
                currentEnemyHealthScript.isBossted = true;
            }
            void WorstEffective()
            {
                currentEnemyHealthScript.hitpoints *= 0.6f;
                currentEnemyHealthScript.maxHealth *= 0.6f;
                currentEnemyMovementScript.movespeed *= 0.8f;
                currentEnemyMovementScript.normalspeed *= 0.8f;
                currentEnemyHealthScript.isBossted = true;
            }
        }
    }

}
