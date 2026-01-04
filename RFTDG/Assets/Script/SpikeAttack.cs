
using System.Collections;
using UnityEngine;

public class SpikeAttack : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float dmg;
    [SerializeField] float Cooldown;
    [SerializeField] LayerMask EnemyLayer;
    Collider2D[] Colliders;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpikePop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpikePop()
    {
        animator.SetTrigger("Attack");
        Colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(2,2),0, EnemyLayer);
        foreach (Collider2D collider in Colliders)
        {
            if (! (collider.GetComponent<HealthScript>().isFlying)) collider.GetComponent<HealthScript>().TakeDamage(dmg);
        }
        yield return new WaitForSeconds(Cooldown);
        StartCoroutine(SpikePop());
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, new Vector2(2, 2));
    }
}
