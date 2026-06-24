using UnityEngine;
using UnityEngine.UIElements;

public class ReaperAbility : MonoBehaviour
{
    [SerializeField] GameObject skeleton;
    [SerializeField] GameObject armoredSkeleton;
    [SerializeField] GameObject giantSkeleton;

    Transform spawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    private void Awake()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("StartingPoint").transform;
    }
    void Update()
    {

    }
    void SpawnSkeleton(string tag)
    {
        GameObject prefabToSpawn = skeleton;

        if (tag == "Untagged")
        {
            prefabToSpawn = skeleton;
        }
        else if (tag == "MiniBoss")
        {
            prefabToSpawn = armoredSkeleton;
        }
        else if (tag == "Boss")
        {
            prefabToSpawn = giantSkeleton;
        }
        else
        {
            prefabToSpawn = null;
        }
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
        }
    }
    private void OnEnable()
    {
        HealthScript.OnEnemyDeath += SpawnSkeleton;
    }

    private void OnDisable()
    {
        HealthScript.OnEnemyDeath -= SpawnSkeleton;
    }
}
