
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MovemenScript : MonoBehaviour
{
    GameObject currentTarget;
    [SerializeField] SpriteRenderer phoenixSprite;
    List<GameObject> listOfEnemies = new List<GameObject>();
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] float movementSpeed;
    public Transform TowerTransform;

    private void Update()
    {
        if (listOfEnemies.Count == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, TowerTransform.position, movementSpeed * Time.deltaTime);
        }
        if (currentTarget == null && listOfEnemies.Count > 0)
        {
            currentTarget = listOfEnemies[0];
        }
        if (currentTarget != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, movementSpeed * Time.deltaTime); 
            if (currentTarget.transform.position.x > transform.position.x)
            {
                phoenixSprite.flipX = false;
            }
            else if (currentTarget.transform.position.x < transform.position.x)
            {
                phoenixSprite.flipX = true;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((enemyLayer & (1 << collision.gameObject.layer)) != 0)
        {
            listOfEnemies.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((enemyLayer & (1 << collision.gameObject.layer)) != 0)
        {
            listOfEnemies.Remove(collision.gameObject);
            if (collision.gameObject == currentTarget)
            {
                currentTarget = null;
            }
        }
    }

}
