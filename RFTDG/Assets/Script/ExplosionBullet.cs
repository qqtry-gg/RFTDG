using Unity.VisualScripting;
using UnityEngine;

public class ExplosionBullet : MonoBehaviour
{
    [SerializeField] float explosionDMG;
    [SerializeField] float ExplosionRadius = 2f;
    Collider2D[] circleColliders;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] GameObject explosionPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        circleColliders = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius, enemyLayer);
        foreach (Collider2D enemy in circleColliders)
        {
            HealthScript healthScript = enemy.GetComponent<HealthScript>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(explosionDMG);
            }
        }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
