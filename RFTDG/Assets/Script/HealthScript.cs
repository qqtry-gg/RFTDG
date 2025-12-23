using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] EnemyMovementScript enemyMovementScript;
    [SerializeField] Image healtBar;
    [SerializeField] SpawnMobsAfterDeath spawnMob;
    [Header("Attributes")]
    [SerializeField] float hitpoints = 2f;
    float maxHealth;
    bool is_PoisonWorking = false;
    bool enemyDied = false;
    public void TakeDamage(float damage)
    {
        hitpoints -= damage;
        healtBar.fillAmount = hitpoints / maxHealth;

        if (hitpoints <= 0)
        {
            animator.SetTrigger("Die");
            if (spawnMob != null && !enemyDied)
            {
                spawnMob.SpawnMobs();
                enemyDied = true;
            }
            enemyDied = true;
            StartCoroutine(DestoryAfterAnimation());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = hitpoints;
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
