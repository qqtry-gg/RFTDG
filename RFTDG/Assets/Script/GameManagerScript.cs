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
        SpawnUnit(Skeleton);
    }
    public void SpawnGoblin()
    {
        SpawnUnit(Goblin);
    }
    public void SpawnWolf()
    {
        SpawnUnit(Wolf);
    }
    public void SpawnOrc()
    {
        SpawnUnit(Orc);
    }
    public void SpawnBat()
    {
        SpawnUnit(Bat);
    }
    public void SpawnArmoredSkeleton()
    {
        SpawnUnit(ArmoredSkeleton);
    }
    public void SpawnGiantMushroom()
    {
        SpawnUnit(GiantMushroom);
    }
    public void SpawnGolem()
    {
        SpawnUnit(Golem);
    }
    public void SpawnGoldGolem()
    {
        SpawnUnit(GoldGolem);
    }
    public void SpawnFylingGolem()
    {
        SpawnUnit(FlyingGolem);
    }
    public void SpawnReinforcedFylingGolem()
    {
        SpawnUnit(ReinforcedFylingGolem);
    }
    public void SpawnSlime()
    {
        SpawnUnit(Slime);
    }
    public void SpawnSlimeBoss()
    {
        SpawnUnit(SlimeBoss);
    }
    public void SpawnNecromanta()
    {
        SpawnUnit(Necromanta);
    }
    public void SpawnGoldBabyDragon()
    {
        SpawnUnit(GoldBabyDragon);
    }
    public void SpawnTwinHeadedRedBabyDragon()
    {
        SpawnUnit(TwinHeadedRedBabyDragon);
    }
    public void SpawnFrostGuardian()
    {
        SpawnUnit(FrostGuardian);
    }
    public void SpawnTheElderMountainsDragon()
    {
        SpawnUnit(TheElderMountainsDragon);
    }
    public void SpawnWarHog()
    {
        SpawnUnit(WarHog);
    }
    public void SpawnGollux()
    {
        SpawnUnit(Gollux);
    }
    public void SpawnBringerOfDeath()
    {
        SpawnUnit(BringerOfDeath);
    }
    void SpawnUnit(GameObject enemy)
    {
        Instantiate(enemy, SpawnPlace.position, Quaternion.identity);
    }
}
