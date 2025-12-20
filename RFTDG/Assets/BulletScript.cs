using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Rigidbody2D rb;



    [Header("Attributes")]
    [SerializeField] float Bulletspeed = 5f;
    [SerializeField] float rotationSpeed = 30f;
    [SerializeField] float dmg = 1f;

    private Transform Target;


    public void SetTarget(Transform _transform)
    {
        Target = _transform;
    }
    private void FixedUpdate()
    {
        if (!Target) return;
        Vector2 direction = (Target.position - transform.position).normalized;

        rb.linearVelocity = direction * Bulletspeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.gameObject.GetComponent<HealthScript>().TakeDamage(dmg);
        Destroy(gameObject);
    }
}
