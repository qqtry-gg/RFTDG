using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] EnemyMovementScript enemyMovementScript;
    [SerializeField] Image healtBar;
    [SerializeField] SpawnMobsAfterDeath spawnMob;
    [SerializeField] Phase2 secondphase;
    [Header("Attributes")]
    public float hitpoints = 2f;
    public float maxHealth;
    float dmg;
    bool is_PoisonWorking = false;
    bool enemyDied = false;
    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            hitpoints -= damage;
        }
        else
        {
            Debug.Log("Problem w TakeDamage w HealtScript");
            return;
        }
        healtBar.fillAmount = hitpoints / maxHealth;

        if (secondphase != null && !enemyDied)
        {
            secondphase.IncreaseSpeed();
        }

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
    public void Regenerate()
    {
        if (hitpoints < maxHealth)
        {
            hitpoints += maxHealth / 100;
            healtBar.fillAmount = hitpoints / maxHealth;
        }
    }
}
