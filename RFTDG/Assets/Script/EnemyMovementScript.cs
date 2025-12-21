using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [Header("Atributes")]
    public float movespeed = 2f;
    [Header("References")]
    [SerializeField] Rigidbody2D rb;

    private Transform target;
    private int pathIndex = 0;

    private void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if (pathIndex == LevelManager.main.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }

        }
    }
    private void Start()
    {
        target = LevelManager.main.path[pathIndex];
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * movespeed;
    }
}
