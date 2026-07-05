using UnityEngine;

public class SpawnMobsAfterDeath : MonoBehaviour
{
    [SerializeField] HealthScript HealthScript;
    [SerializeField] int amountofMobs;
    [SerializeField] GameObject MobToSpawn;
    [SerializeField] Vector3 Separation;
    [SerializeField] Vector3 offset;
    GameManagerScript gameManagerScript;
    GameObject EnemySpawned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        gameManagerScript = FindFirstObjectByType<GameManagerScript>();
    }
    public void SpawnMobs()
    {
        for (int i = 0; i < amountofMobs; i++)
        {
            offset = Separation * i;
            EnemySpawned = Instantiate(MobToSpawn, transform.position + offset,  Quaternion.identity);
            gameManagerScript.enemies.Add(EnemySpawned);
            EnemySpawned.GetComponent<EnemyMovementScript>().pathIndex = gameObject.GetComponent<EnemyMovementScript>().pathIndex;
        }
    }

}
