using UnityEngine;

public class GroundBreakerAttack : MonoBehaviour
{
    AudioManager audioManager;
    Collider2D[] enemyColliders;
    float timer = 0f;
    [Header("Attributes")]
    [SerializeField] LayerMask enemyLayerMask;
    [SerializeField] float radius;
    [SerializeField] float attackSpeed;
    [SerializeField] float damage;
    [SerializeField] Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= attackSpeed)
        {
            GroundBreakerAttackMethod();
            
            timer = 0f;
        }

    }
    void GroundBreakerAttackMethod()
    {
        enemyColliders = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayerMask);
        animator.SetTrigger("Attack");
        audioManager.PlaySFX(audioManager.groundbreakerTowerAttack);
        foreach (Collider2D enemy in enemyColliders)
        {
            enemy.GetComponent<HealthScript>().TakeDamage(damage);
        }

    }
       
}
