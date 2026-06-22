using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BoostRaidousScript : MonoBehaviour
{
    [SerializeField] HealthScript healthScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthScript>() != null)
        {
            if (collision.GetComponent<HealthScript>().enemyType == healthScript.enemyType && collision.gameObject != gameObject && collision.GetComponent<HealthScript>().isBosstedByBoss == false)
            {
                HealthScript enemyHealthScript = collision.GetComponent<HealthScript>();
                EnemyMovementScript enemyMovementScript = collision.GetComponent<EnemyMovementScript>();
                enemyHealthScript.hitpoints *= 1.2f;
                enemyHealthScript.maxHealth *= 1.2f;
                enemyMovementScript.movespeed *= 1.1f;
                enemyMovementScript.normalspeed *= 1.1f;
                enemyHealthScript.isBosstedByBoss = true;

            }
        }
    }
}
