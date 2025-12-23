using UnityEngine;

public class SlowmoScript : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;
    EnemyMovementScript enemyMovementScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemyLayer) != 0)
        {
            enemyMovementScript = collision.gameObject.GetComponent<EnemyMovementScript>();
            enemyMovementScript.ChangeSpeed(2);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & enemyLayer) != 0)
        {
            enemyMovementScript = collision.gameObject.GetComponent<EnemyMovementScript>();
            enemyMovementScript.ChangeSpeed(enemyMovementScript.normalspeed / 2);
        }
    }
}
