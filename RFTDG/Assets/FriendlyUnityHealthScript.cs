using UnityEngine;

public class FriendlyUnityHealthScript : MonoBehaviour
{
    [SerializeField] float unitHitPoints;
    [SerializeField] float animationInvokeDelay = 0.5f;
    [SerializeField] FriendlyUnityMovementScript movementScript;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask enemyLayer;
    HealthScript healthScript;
    float hpToDeal;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((enemyLayer & (1 << collision.gameObject.layer)) != 0)
        {
            healthScript = collision.gameObject.GetComponent<HealthScript>();
            if (healthScript != null)
            {
                hpToDeal = healthScript.hitpoints;
                healthScript.TakeDamage(unitHitPoints);
            }
            unitHitPoints -= hpToDeal;
            if (unitHitPoints <= 0)
            {
                unitHitPoints = 0;
                movementScript.MovementSpeed = 0f;
                animator.SetTrigger("Die");
                Invoke("DestroyUnit", animationInvokeDelay);
            }
        }
    }
    void DestroyUnit()
    {
        Destroy(gameObject);
    }
}
