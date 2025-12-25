using System.Collections;
using UnityEditor;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    [Header("Atributes")]
    public float movespeed = 2f;
    [Header("References")]
    [SerializeField] Rigidbody2D rb;

    private Transform target;
    public int pathIndex = 0;
    [SerializeField] bool isSpriteRotated = false;

    Vector3 previousPosition;
    SpriteRenderer spriteRenderer;
    public float normalspeed;

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
        previousPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        target = LevelManager.main.path[pathIndex];
    }
    private void Awake()
    {
        normalspeed = movespeed;
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.linearVelocity = direction * movespeed;

        Vector3 currentPositon = transform.position;
        float movementX = currentPositon.x - previousPosition.x;
        if (!isSpriteRotated)
        {
            if (movementX > 0.01f) //idzie w prawo
            {
                spriteRenderer.flipX = false;
            }
            else if (movementX < -0.01f) //idzie w lewo
            {
                spriteRenderer.flipX = true;
            }
        }
        else
        {
            if (movementX > 0.01f) //idzie w prawo
            {
                spriteRenderer.flipX = true;
            }
            else if (movementX < -0.01f) //idzie w lewo
            {
                spriteRenderer.flipX = false;
            }
        }

            previousPosition = currentPositon;
    }
    public void ChangeSpeed(float newSpeed)
    {
        movespeed = newSpeed;
    }
    public void StartFreze(float FreezeTimefr)
    {
        StartCoroutine(Freeze(FreezeTimefr));
    }
    IEnumerator Freeze(float Freezetime)
    {
        movespeed = 0;
        spriteRenderer.color = Color.lightBlue;
        yield return new WaitForSeconds(Freezetime);
        spriteRenderer.color = Color.white;
        movespeed = normalspeed;
    }
}
