using System.Collections;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] float hitpoints = 2f;
    bool is_PoisonWorking = false;

    public void TakeDamage(float damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0)
        {
            Destroy(gameObject);
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
            for (int i = 3; PoisonHitCounter <= i;)
            {
                yield return new WaitForSeconds(PoisonCooldownBeforeDMG);
                PoisonHitCounter++;
                TakeDamage(PoisonDMG);
            }
            is_PoisonWorking = false;
            PoisonHitCounter = 0;
        }
    }
}
