using System.Collections;
using UnityEngine;

public class Phase2 : MonoBehaviour
{
    [SerializeField] float SpeedIncreaseTimes = 3f;
    [SerializeField] float Hp2Phase;
    [SerializeField] HealthScript HealthScript;
    [SerializeField] EnemyMovementScript EnemyMovementScript;
    [SerializeField] float secondsTransformationCooldown = 2f;
    [SerializeField] Animator animator;
    bool used = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IncreaseSpeed()
    {
        if (HealthScript.hitpoints <= Hp2Phase && !used)
        {
            StartCoroutine(Transformation());
            used = true;
        }
    }
    IEnumerator Transformation()
    {
        EnemyMovementScript.movespeed = 0;
        animator.SetBool("Transformation", true);
        HealthScript.hitpoints += HealthScript.maxHealth / 5;
        yield return new WaitForSeconds(secondsTransformationCooldown);
        EnemyMovementScript.normalspeed = EnemyMovementScript.normalspeed * SpeedIncreaseTimes;
        animator.SetBool("Transformation", false);
        GetComponent<SpriteRenderer>().material.color = Color.darkRed;
        EnemyMovementScript.movespeed = EnemyMovementScript.normalspeed * SpeedIncreaseTimes;
    }
}
