using System.Collections;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] EnemyMovementScript enemyMovementScript;
    [Header("Attributes")]
    [SerializeField] float hitpoints = 2f;
    bool is_PoisonWorking = false;

    public void TakeDamage(float damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0)
        {
            animator.SetTrigger("Die");
            StartCoroutine(DestoryAfterAnimation());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartPosionEffect(int PoisonHitCounter, float PoisonCooldownBeforeDMG, float PoisonDMG)
    {
        StartCoroutine(Poison(PoisonHitCounter, PoisonCooldownBeforeDMG,PoisonDMG));
    }
    IEnumerator Poison(int PoisonHitCounter, float PoisonCooldownBeforeDMG, float PoisonDMG)
    {
        if (!is_PoisonWorking)
        {
            is_PoisonWorking = true;
            for (int i = 4; PoisonHitCounter <= i;)
            {
                yield return new WaitForSeconds(PoisonCooldownBeforeDMG);
                PoisonHitCounter++;
                TakeDamage(PoisonDMG);
            }
            is_PoisonWorking = false;
            PoisonHitCounter = 0;
        }
    }
    IEnumerator DestoryAfterAnimation()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        enemyMovementScript.movespeed = 0f;
        yield return new WaitForSeconds(stateInfo.length);
        Destroy(gameObject);
    }

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
