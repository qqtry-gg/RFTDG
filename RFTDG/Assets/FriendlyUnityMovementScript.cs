using UnityEngine;

public class FriendlyUnityMovementScript : MonoBehaviour
{
    public float MovementSpeed = 2f;
    [SerializeField] SpriteRenderer spriteRenderer;
    LevelManager levelManager;
    int count = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= levelManager.PathU.Length)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, levelManager.PathU[count].position, MovementSpeed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, levelManager.PathU[count].position);
        if (distance <= 0.1f) 
        {
            count++;
        }
        if (transform.position.x - levelManager.PathU[count].transform.position.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
