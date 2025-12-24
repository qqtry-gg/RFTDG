using System.Collections;
using UnityEngine;

public class PassiveRegeneration : MonoBehaviour
{
    [SerializeField] HealthScript hp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Regenerate());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Regenerate()
    {
        if (hp.hitpoints > 0)
        {
            yield return new WaitForSeconds(1);
            hp.Regenerate();
            StartCoroutine(Regenerate());
        }
    }
}
