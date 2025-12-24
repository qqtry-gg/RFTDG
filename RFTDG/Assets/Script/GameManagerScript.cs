using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnSkeleton()
    {
        Instantiate(Skeleton, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnGoblin()
    {
        Instantiate(Goblin, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnWolf()
    {
        Instantiate(Wolf, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnOrc()
    {
        Instantiate(Orc, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnBat()
    {
        Instantiate(Bat, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnArmoredSkeleton()
    {
        Instantiate(ArmoredSkeleton, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnGiantMushroom()
    {
        Instantiate(GiantMushroom, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnGolem()
    {
        Instantiate(Golem, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnGoldGolem()
    {
        Instantiate(GoldGolem, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnFylingGolem()
    {
        Instantiate(FlyingGolem, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnReinforcedFylingGolem()
    {
        Instantiate(ReinforcedFylingGolem, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnSlime()
    {
        Instantiate(Slime, SpawnPlace.position, Quaternion.identity);
    }
    public void SpawnSlimeBoss()
    {
        Instantiate(SlimeBoss, SpawnPlace.position, Quaternion.identity);
    }
}
