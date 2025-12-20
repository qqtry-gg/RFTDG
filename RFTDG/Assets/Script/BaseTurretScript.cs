using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.Rendering;


public class BaseTurretScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Sprite DownAttack;
    [SerializeField] Sprite SideAttack;
    [SerializeField] Sprite UpAttack;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] SpriteRenderer CurrentSprite;
    [SerializeField] Transform ObjectToRotate;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform FiringPoint;

    [Header("Atributes")]
    [SerializeField] float targetingRange = 5f;
    [SerializeField] float RotationSpeed = 5f;
    [SerializeField] float bps = 0.8f; //bullets per second
    [SerializeField] float timeBeforeAnimation = 0.3f;

    private Transform target;
    private float TimeUntilFire;

    private void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        RotateTowardsTarget();

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            TimeUntilFire += Time.deltaTime;

            if (TimeUntilFire >= 1f / bps)
            {
                Shoot();
                TimeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        animator.SetTrigger("Attack");
        Invoke("Shoot2", timeBeforeAnimation);
    }
    private void Shoot2()
    {
        GameObject bulletOBJ = Instantiate(BulletPrefab, FiringPoint.position, Quaternion.identity);
        BulletScript bulletscript = bulletOBJ.GetComponent<BulletScript>();
        bulletscript.SetTarget(target);
    }
    private void FindTarget()
    {

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
#endif
    private void RotateTowardsTarget() // je¿eli jednostka jest jednostk¹ która ma 4 kierunki
    {
        Vector2 direction = target.position - transform.position;

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0) //prawo
            {
                CurrentSprite.sprite = SideAttack;
                ObjectToRotate.rotation = Quaternion.Euler(0, 180, 0);
                animator.SetInteger("Direction", 0);
            }
            else //lewo
            {
                CurrentSprite.sprite = SideAttack;
                ObjectToRotate.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetInteger("Direction", 0);
            }
        }
        else
        {
            if (direction.y > 0) //góra
            {
                CurrentSprite.sprite = UpAttack;
                ObjectToRotate.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetInteger("Direction", 2);
            }
            else
            {
                CurrentSprite.sprite = DownAttack;
                ObjectToRotate.rotation = Quaternion.Euler(0, 0, 0);
                animator.SetInteger("Direction", 1);
            }
        }
    }
    Animator animator;
    private void Awake()
    {
         animator = GetComponentInChildren<Animator>();   
    }
    //private void RotateTowardsTarget() //je¿eli jednostka jest jednostk¹ która ma krêciæ g³ow¹
    //{
    //    float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

    //    Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
    //    ObjectToRotate.rotation = Quaternion.RotateTowards(ObjectToRotate.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    //}
}
