using System.Collections;
using UnityEngine;
using TMPro;
using NUnit.Framework;
using System.Collections.Generic;

public class GameManagerScript : MonoBehaviour
{
    [Header("GameAttributes")]
    public int health;
    public int cash;
    [SerializeField] float cooldown;
    [Header("Monster")]
    [SerializeField] Transform SpawnPlace;
    [SerializeField] GameObject Skeleton;
    [SerializeField] GameObject Bat;
    [SerializeField] GameObject Slime;
    [SerializeField] GameObject Goblin;
    [SerializeField] GameObject Wolf;
    [SerializeField] GameObject Orc;
    [SerializeField] GameObject ArmoredSkeleton;
    [SerializeField] GameObject SlimeBoss;
    [SerializeField] GameObject FlyingGolem;
    [SerializeField] GameObject GiantMushroom;
    [SerializeField] GameObject Golem;
    [SerializeField] GameObject GoldGolem;
    [SerializeField] GameObject ReinforcedFylingGolem;
    [SerializeField] GameObject Necromanta;
    [SerializeField] GameObject GoldBabyDragon;
    [SerializeField] GameObject TwinHeadedRedBabyDragon;
    [SerializeField] GameObject FrostGuardian;
    [SerializeField] GameObject TheElderMountainsDragon;
    [SerializeField] GameObject WarHog;
    [SerializeField] GameObject Gollux;
    [SerializeField] GameObject BringerOfDeath;
    [SerializeField] GameObject FlyingSkull;
    [SerializeField] GameObject Healer;
    [SerializeField] GameObject Bandit;
    [Header("UI")]
    [SerializeField] GameObject CashUI;
    [SerializeField] GameObject CooldownUI;
    

    bool canSpawn = true;
    public List<GameObject> enemies = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CashUI.GetComponent<TextMeshProUGUI>().text = "Cash: " + cash.ToString();
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            CooldownUI.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            CooldownUI.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        CooldownUI.GetComponent<TextMeshProUGUI>().text = "Cooldown: " + (Mathf.Round(cooldown * 100) / 100).ToString();
    }
    public void DecreaseHealth(int amountofHealthToDecrese)
    {
        health -= amountofHealthToDecrese;
        if (health <= 0)
        {
            Debug.Log("You lost");
        }
    }
    public void SpawnSkeleton()
    {
        SpawnUnit(Skeleton, 0.1f,2);
    }
    public void SpawnGoblin()
    {
        SpawnUnit(Goblin, 0.2f,5);
    }
    public void SpawnWolf()
    {
        SpawnUnit(Wolf, 0.3f,10);
    }
    public void SpawnOrc()
    {
        SpawnUnit(Orc, 0.4f,20);
    }
    public void SpawnBat()
    {
        SpawnUnit(Bat, 0.1f,2);
    }
    public void SpawnArmoredSkeleton()
    {
        SpawnUnit(ArmoredSkeleton, 0.45f,30);
    }
    public void SpawnGiantMushroom()
    {
        SpawnUnit(GiantMushroom, 0.6f,75);
    }
    public void SpawnGolem()
    {
        SpawnUnit(Golem, 1f,125);
    }
    public void SpawnGoldGolem()
    {
        SpawnUnit(GoldGolem, 1.25f,150);
    }
    public void SpawnFylingGolem()
    {
        SpawnUnit(FlyingGolem, 0.75f,85);
    }
    public void SpawnReinforcedFylingGolem()
    {
        SpawnUnit(ReinforcedFylingGolem, 1.5f,250);
    }
    public void SpawnSlime()
    {
        SpawnUnit(Slime, 0.3f,3);
    }
    public void SpawnSlimeBoss()
    {
        SpawnUnit(SlimeBoss, 0.75f,50);
    }
    public void SpawnNecromanta()
    {
        SpawnUnit(Necromanta, 3f,350);
    }
    public void SpawnGoldBabyDragon()
    {
        SpawnUnit(GoldBabyDragon, 4f,750);
    }
    public void SpawnTwinHeadedRedBabyDragon()
    {
        SpawnUnit(TwinHeadedRedBabyDragon, 4.5f,1000);
    }
    public void SpawnFrostGuardian()
    {
        SpawnUnit(FrostGuardian, 7.5f,1750);
    }
    public void SpawnTheElderMountainsDragon()
    {
        SpawnUnit(TheElderMountainsDragon, 30f,7500);
    }
    public void SpawnWarHog()
    {
        SpawnUnit(WarHog, 0.8f,50);
    }
    public void SpawnGollux()
    {
        SpawnUnit(Gollux, 3.5f,400);
    }
    public void SpawnBringerOfDeath()
    {
        SpawnUnit(BringerOfDeath, 12.5f,2500);
    }
    public void SpawnFlyingSkull()
    {
        SpawnUnit(FlyingSkull, 0.25f, 8);
    }
    public void SpawnHealer()
    {
        SpawnUnit(Healer, 2.25f, 100);
    }
    public void SpawnBandit()
    {
        SpawnUnit(Bandit, 0.5f, 35);
    }
    void SpawnUnit(GameObject enemy, float time, int cost)
    {
        enemies.Add(enemy);
        StartCoroutine(Cooldown(enemy, time, cost));
    }
    IEnumerator Cooldown(GameObject unit, float time, int cost)
    {
        if (canSpawn == true && cash >= cost)
        {
            cooldown = time;
            cash -= cost;
            canSpawn = false;

            Instantiate(unit, SpawnPlace.position, Quaternion.identity);
            yield return new WaitForSeconds(time);
            canSpawn = true;
        }
    }
}
