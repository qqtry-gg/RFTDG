using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [SerializeField] EnemyMovementScript enemyMovementScript;
    [SerializeField] GameManagerScript gameManagerScript;
    [SerializeField] Image healtBar;
    [SerializeField] SpawnMobsAfterDeath spawnMob;
    [SerializeField] Phase2 secondphase;
    AudioManager audioManager;
    [Header("Attributes")]
    public bool isFlying = false;
    public float hitpoints = 2f;
    public float maxHealth;
    public bool isBossted;
    public bool isBosstedByBoss;
    float dmg;
    bool is_PoisonWorking = false;
    bool enemyDied = false;
    public static Action<String> OnEnemyDeath;
    


    public enum Type
    {
        Normal,
        Fire,
        Ice,
        Grass,
        Rock,
        Death
    }
    public Type enemyType;
    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            hitpoints -= damage;
        }
        else
        {
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
    public void Heal(float healAmount)
    {
        if (hitpoints + healAmount < maxHealth) hitpoints += healAmount;
        else
        {
            hitpoints = maxHealth;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManagerScript = FindAnyObjectByType<GameManagerScript>();
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
        OnEnemyDeath?.Invoke(gameObject.tag);
        if (gameObject.CompareTag("Boss"))
        {
            gameManagerScript.SetBossTo0();
        }
        audioManager.PlaySFX(audioManager.enemyDeath);
        Destroy(gameObject);
    }

    Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioManager = FindFirstObjectByType<AudioManager>();
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
