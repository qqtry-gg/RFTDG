using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class RNDSpawning : MonoBehaviour
{
    [SerializeField] List<Transform> spawns = new List<Transform>();
    [SerializeField] GameObject[] towers;
    Transform currentSpawn;
    GameObject currentTower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && spawns.Count > 0)
        {
            int randomSpawnInt = UnityEngine.Random.Range(0, spawns.Count);
            currentSpawn = spawns[randomSpawnInt];

            int randomTowerInt = UnityEngine.Random.Range(0, towers.Length);
            currentTower = towers[randomTowerInt];

            Instantiate(currentTower, currentSpawn.transform.position, Quaternion.identity);
            spawns.Remove(currentSpawn);
        }
    }
}
