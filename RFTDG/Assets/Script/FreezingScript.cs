using JetBrains.Annotations;
using UnityEngine;

public class FreezingScript : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] EnemyMovementScript enemyMovementScript;
    [SerializeField] float FreezeTime;
    bool isUsed = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((enemyLayer & (1 << collision.gameObject.layer)) != 0 && !isUsed && !(collision.gameObject.CompareTag("Boss")) && !(collision.gameObject.CompareTag("MiniBoss")))
        {
            enemyMovementScript = collision.gameObject.GetComponent<EnemyMovementScript>();
            enemyMovementScript.StartFreze(FreezeTime);
            isUsed = true;
        }
    }
}
