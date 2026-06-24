using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] HealthScript healthScript;
    [SerializeField] EnemyMovementScript enemyMovementScript;
    [SerializeField] float cooldownBeforBlock;
    [SerializeField] float blockDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(BlockCooldown());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator BlockCooldown()
    {
        yield return new WaitForSeconds(cooldownBeforBlock);
        animator.SetTrigger("Block");
        healthScript.hitpoints = healthScript.hitpoints * 10;
        healthScript.maxHealth = healthScript.maxHealth * 10;
        enemyMovementScript.movespeed = 0;
        yield return new WaitForSeconds(blockDuration);
        animator.SetTrigger("Idle");
        healthScript.hitpoints = healthScript.hitpoints / 10;
        healthScript.maxHealth = healthScript.maxHealth / 10;
        enemyMovementScript.movespeed = enemyMovementScript.normalspeed;
        StartCoroutine(BlockCooldown());
    }
}
