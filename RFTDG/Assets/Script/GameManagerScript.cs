using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] Transform SpawnPlace;
    [SerializeField] GameObject Skeleton;
    [SerializeField] GameObject Goblin;
    [SerializeField] GameObject Wolf;
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
}
