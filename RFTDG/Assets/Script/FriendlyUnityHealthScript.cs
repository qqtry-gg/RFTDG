using System.Collections;
using UnityEngine;

public class FriendlyUnityHealthScript : MonoBehaviour
{
    [SerializeField] float unitHitPoints;
    [SerializeField] FriendlyUnityMovementScript movementScript;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask enemyLayer;
    HealthScript healthScript;
    bool isDying = false;
    float dmg;
    float enemydmg;

    private void Start()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((enemyLayer & (1 << collision.gameObject.layer)) != 0)
        {
            healthScript = collision.gameObject.GetComponent<HealthScript>();
            dmg = unitHitPoints;
            enemydmg = healthScript.hitpoints;
            healthScript.TakeDamage(dmg);
            if (enemydmg > 0)
            {
                unitHitPoints -= enemydmg;
            }
            if (unitHitPoints <= 0 && !isDying)
            {
                StartCoroutine(DieAnimation());
                isDying = true;
            }
        }
    }
    IEnumerator DieAnimation()
    {
        GetComponent<Collider2D>().enabled = false;
        movementScript.MovementSpeed = 0f;
        GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("Die");
        float animationDuration = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(animationDuration); // czas trwania animacji
        Destroy(gameObject);
    }
}
