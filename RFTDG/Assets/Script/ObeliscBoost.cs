using UnityEngine;

public class ObeliscBoost : MonoBehaviour
{

    [SerializeField] float radius = 5f;
    [SerializeField] LayerMask towerLayer;
    Collider2D[] circleColliders;
    float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 5f)
        {
            TowersInRange();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
    public void TowersInRange()
    {
        circleColliders = Physics2D.OverlapCircleAll(transform.position, radius, towerLayer);
        if (circleColliders.Length > 0)
        {
            foreach(Collider2D circleCollider in circleColliders)
            {
                BaseTurretScript currentTower = circleCollider.GetComponent<BaseTurretScript>();
                if (currentTower != null)
                {
                    if (currentTower.isBoosted == false)
                    {
                        currentTower.targetingRange = (currentTower.targetingRange + currentTower.targetingRange / 5);
                        currentTower.bps = currentTower.bps * 1.2f;
                        currentTower.isBoosted = true;
                    }

                }

            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
