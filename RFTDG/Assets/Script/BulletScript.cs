using System.Collections;
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
        StartCoroutine(DestroyObjectAfterTime(5));
        if (!Target) return;
        Vector2 direction = (Target.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0, angle - 90f);

        rb.linearVelocity = direction * Bulletspeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.gameObject.GetComponent<HealthScript>().TakeDamage(dmg);
        Destroy(gameObject);
    }
    IEnumerator DestroyObjectAfterTime(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
