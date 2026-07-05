using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] float timeBeforeRespawning;
    [SerializeField] GameObject unitToSpawn;
    GameManagerScript gameManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerScript = FindFirstObjectByType<GameManagerScript>();
        StartCoroutine(RespawnAfterTime());
    }
    IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(timeBeforeRespawning);
        GameObject newGolem = Instantiate(unitToSpawn, transform.position, Quaternion.identity);
        gameManagerScript.enemies.Add(newGolem);
        newGolem.GetComponent<EnemyMovementScript>().pathIndex = gameObject.GetComponent<EnemyMovementScript>().pathIndex;
        Destroy(gameObject);
    }
}
