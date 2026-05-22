using UnityEngine;

public class HealingScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    Collider2D[] circleColliders;
    [SerializeField] float HealingRadius;
    [SerializeField] LayerMask allyLayer;
    [SerializeField] float HealingHP;

    [SerializeField] float cooldown;
    float startingCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingCooldown = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (cooldown <= 0)
        {
            animator.SetTrigger("Heal");
            cooldown = startingCooldown;
            Heal();
        }
    }
    void Heal()
    {
        circleColliders = Physics2D.OverlapCircleAll(transform.position, HealingRadius, allyLayer);
        foreach (Collider2D ally in circleColliders)
        {
            HealthScript healthScript = ally.GetComponent<HealthScript>();
            if (healthScript != null)
            {
                if (ally.gameObject != gameObject)
                {
                    healthScript.Heal(HealingHP);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, HealingRadius);
    }
}
