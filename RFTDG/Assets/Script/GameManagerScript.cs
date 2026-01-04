using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [Header("GameAttributes")]
    [SerializeField] int health;
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

    bool canSpawn = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SpawnUnit(Skeleton, 0.1f);
    }
    public void SpawnGoblin()
    {
        SpawnUnit(Goblin, 0.2f);
    }
    public void SpawnWolf()
    {
        SpawnUnit(Wolf, 0.2f);
    }
    public void SpawnOrc()
    {
        SpawnUnit(Orc, 0.3f);
    }
    public void SpawnBat()
    {
        SpawnUnit(Bat, 0.1f);
    }
    public void SpawnArmoredSkeleton()
    {
        SpawnUnit(ArmoredSkeleton, 0.3f);
    }
    public void SpawnGiantMushroom()
    {
        SpawnUnit(GiantMushroom, 0.4f);
    }
    public void SpawnGolem()
    {
        SpawnUnit(Golem, 0.5f);
    }
    public void SpawnGoldGolem()
    {
        SpawnUnit(GoldGolem, 0.5f);
    }
    public void SpawnFylingGolem()
    {
        SpawnUnit(FlyingGolem, 0.4f);
    }
    public void SpawnReinforcedFylingGolem()
    {
        SpawnUnit(ReinforcedFylingGolem, 0.6f);
    }
    public void SpawnSlime()
    {
        SpawnUnit(Slime, 0.2f);
    }
    public void SpawnSlimeBoss()
    {
        SpawnUnit(SlimeBoss, 0.5f);
    }
    public void SpawnNecromanta()
    {
        SpawnUnit(Necromanta, 2f);
    }
    public void SpawnGoldBabyDragon()
    {
        SpawnUnit(GoldBabyDragon, 2f);
    }
    public void SpawnTwinHeadedRedBabyDragon()
    {
        SpawnUnit(TwinHeadedRedBabyDragon, 2.5f);
    }
    public void SpawnFrostGuardian()
    {
        SpawnUnit(FrostGuardian, 5f);
    }
    public void SpawnTheElderMountainsDragon()
    {
        SpawnUnit(TheElderMountainsDragon, 30f);
    }
    public void SpawnWarHog()
    {
        SpawnUnit(WarHog, 0.4f);
    }
    public void SpawnGollux()
    {
        SpawnUnit(Gollux, 1f);
    }
    public void SpawnBringerOfDeath()
    {
        SpawnUnit(BringerOfDeath, 10f);
    }
    void SpawnUnit(GameObject enemy, float time)
    {

        StartCoroutine(Cooldown(enemy, time));
    }
    IEnumerator Cooldown(GameObject unit, float time)
    {
        if (canSpawn == true)
        {
            canSpawn = false;
            Instantiate(unit, SpawnPlace.position, Quaternion.identity);
            yield return new WaitForSeconds(time);
            canSpawn = true;
        }
    }
}
