using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] float timeBeforeRespawning;
    [SerializeField] GameObject unitToSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(RespawnAfterTime());
    }
    IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(timeBeforeRespawning);
        Instantiate(unitToSpawn, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
