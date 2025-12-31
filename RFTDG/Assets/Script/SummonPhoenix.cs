using UnityEngine;

public class SummonPhoenix : MonoBehaviour
{
    [SerializeField] GameObject PhoenixPrefab;
    [SerializeField] MovemenScript phoenixMovementScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phoenixMovementScript = PhoenixPrefab.GetComponent<MovemenScript>();
        phoenixMovementScript.TowerTransform = gameObject.transform;
        Instantiate(PhoenixPrefab, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
