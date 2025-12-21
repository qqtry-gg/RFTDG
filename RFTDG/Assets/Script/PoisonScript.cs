using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PoisonScript : MonoBehaviour
{
    [SerializeField] HealthScript EnemyHealth;
    [SerializeField] int PoisonHitCounter = 0;
    [SerializeField] float PoisonCooldownBeforeDMG = 1f;
    [SerializeField] float PoisonDMG = 1f;
    bool is_PoisonWorking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyHealth = collision.transform.gameObject.GetComponent<HealthScript>();
        if (EnemyHealth != null )
        {
            EnemyHealth.StartPosionEffect(PoisonHitCounter,PoisonCooldownBeforeDMG,PoisonDMG);
        }
    }
}

