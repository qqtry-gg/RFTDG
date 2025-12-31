using System.Collections;
using UnityEngine;

public class SummonFriendlyUnity : MonoBehaviour
{
    [SerializeField] float Cooldown;
    [SerializeField] float NextSpawnCooldown = 0.25f;
    [SerializeField] int AmountofUnits;
    LevelManager LevelManager;
    [SerializeField] GameObject unit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        LevelManager = FindAnyObjectByType<LevelManager>();
    }
    void Start()
    {
        StartCoroutine(Summon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Summon()
    {
        if (unit != null && LevelManager != null)
        {
            for (int i = 0; i < AmountofUnits; i++)
            {
                Instantiate(unit, LevelManager.startPointU.position, Quaternion.identity);
                yield return new WaitForSeconds(NextSpawnCooldown);
            }
        }
        else
        {
            Debug.Log("Please don't leave unit Empty");
        }
        yield return new WaitForSeconds(Cooldown);
        StartCoroutine(Summon());
    }
}
