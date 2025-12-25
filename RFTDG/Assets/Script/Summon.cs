using System.Collections;
using UnityEngine;

public class Summon : MonoBehaviour
{
    [SerializeField] int amountofMobs;
    [SerializeField] float timebeforenextsummon = 10f;
    [SerializeField] GameObject MobToSpawn;
    [SerializeField] Vector3 Separation;
    [SerializeField] Vector3 offset;
    [SerializeField] Animator animator;
    [SerializeField] EnemyMovementScript EnemyMovementScript;
    GameObject EnemySpawned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        StartCoroutine(Spawning());
    }
    public void SpawnMobs()
    {
        for (int i = 0; i < amountofMobs; i++)
        {
            offset = Separation * i;
            EnemySpawned = Instantiate(MobToSpawn, transform.position + offset, Quaternion.identity);
            EnemySpawned.GetComponent<EnemyMovementScript>().pathIndex = gameObject.GetComponent<EnemyMovementScript>().pathIndex;
        }
    }
    IEnumerator Spawning()
    {
        animator.SetTrigger("Summon");
        EnemyMovementScript.movespeed = 0;
        yield return new WaitForSeconds(1.65f);
        SpawnMobs();
        EnemyMovementScript.movespeed = EnemyMovementScript.normalspeed;
        yield return new WaitForSeconds(timebeforenextsummon - 2);
        StartCoroutine(Spawning());
    }
}
