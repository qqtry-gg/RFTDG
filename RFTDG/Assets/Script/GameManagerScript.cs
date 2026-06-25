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
    public float cooldown;
    int AmountOfBosses;
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
    [SerializeField] GameObject FlyingDemon;
    [SerializeField] GameObject Rat;
    [SerializeField] GameObject Imp;
    [SerializeField] GameObject MechaStoneGolem;
    [SerializeField] GameObject SkeletonWithMace;
    [SerializeField] GameObject FinalBoss;
    [SerializeField] GameObject IceWolf;
    [SerializeField] GameObject Reaper;
    [SerializeField] GameObject IceGolem;
    [SerializeField] GameObject IceSlime;
    [SerializeField] GameObject IceSlimeBoss;
    [SerializeField] GameObject FlyingIceGolem;
    [SerializeField] GameObject GrassGolemBoss;
    [Header("UI")]
    [SerializeField] GameObject CashUI;
    [SerializeField] GameObject CooldownUI;
    

    bool canSpawn = true;
    public GameObject[] bossButtons;
    [HideInInspector]
    public List<GameObject> enemies = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AmountOfBosses <= 0)
        {
            foreach(GameObject bossButtons in bossButtons)
            {
                bossButtons.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject bossButtons in bossButtons)
            {
                bossButtons.SetActive(false);
            }
        }
        CashUI.GetComponent<TextMeshProUGUI>().text = cash.ToString();
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            CooldownUI.GetComponent<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            CooldownUI.GetComponent<TextMeshProUGUI>().color = Color.green;
        }
        if (cooldown > 0) CooldownUI.GetComponent<TextMeshProUGUI>().text = (Mathf.Round(cooldown * 100) / 100).ToString();
        else CooldownUI.GetComponent<TextMeshProUGUI>().text = "0";
    }
    public void DecreaseHealth(int amountofHealthToDecrese)
    {
        health -= amountofHealthToDecrese;
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
        SpawnUnit(Healer, 2.25f, 200);
    }
    public void SpawnBandit()
    {
        SpawnUnit(Bandit, 0.5f, 35);
    }
    public void SpawnFlyingDemon()
    {
        SpawnUnit(FlyingDemon, 0.55f, 40);
    }
    public void SpawnRat()
    {
        SpawnUnit(Rat, 0.05f, 1);
    }
    public void SpawnImp()
    {
        SpawnUnit(Imp, 2f, 325);
    }
    public void SpawnMechaStoneGolem()
    {
        SpawnUnit(MechaStoneGolem, 3f, 600);
    }
    public void SpawnSkeletonWithMace()
    {
        SpawnUnit(SkeletonWithMace, 0.45f, 60);
    }
    public void SpawnFinalBoss()
    {
        SpawnUnit(FinalBoss, 60f, 17500);
    }
    public void SpawnIceWolf()
    {
        SpawnUnit(IceWolf, 0.35f, 12);
    }
    public void SpawnReaper()
    {
        SpawnUnit(Reaper, 35f, 12500);
    }
    public void SpawnIceGolem()
    {
        SpawnUnit(IceGolem, 0.8f, 100);
    }
    public void SpawnIceSlime()
    {
        SpawnUnit(IceSlime, 0.4f, 25);
    }
    public void SpawnIceSlimeBoss()
    {
        SpawnUnit(IceSlimeBoss, 0.6f, 70);
    }
    public void SpawnFlyingIceGolem()
    {
        SpawnUnit(FlyingIceGolem, 2f, 500);
    }
    public void SpawnGrassGolemBoss()
    {
        SpawnUnit(GrassGolemBoss, 25f, 6000);
    }

    void SpawnUnit(GameObject enemy, float time, int cost)
    {
        StartCoroutine(Cooldown(enemy, time, cost));
    }
    IEnumerator Cooldown(GameObject unit, float time, int cost)
    {
        if (canSpawn == true && cash >= cost)
        {
            cooldown = time;
            cash -= cost;
            canSpawn = false;

            GameObject spawnedEnemy = Instantiate(unit, SpawnPlace.position, Quaternion.identity);
            enemies.Add(spawnedEnemy);
            
            yield return new WaitForSeconds(time);
            canSpawn = true;
        }
    }
    public void AddBoss()
    {
        AmountOfBosses++;
    }
    public void DeleteBoss()
    {
        AmountOfBosses--;
    }
    public void SetBossTo0()
    {
        AmountOfBosses = 0;
    }
}
