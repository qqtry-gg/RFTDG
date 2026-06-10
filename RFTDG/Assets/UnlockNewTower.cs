using NUnit.Framework;
using UnityEngine;

public class UnlockNewTower : MonoBehaviour
{
    [SerializeField] EndlessModeManager endlessModeManager;
    [SerializeField] GameObject[] enemyButtons;
    public bool isChecked = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (endlessModeManager.wave == 5 && !isChecked)
        {
            CheckCurrentUnlockedTower();
            isChecked = true;
        }
        else if (endlessModeManager.wave % 8 == 0 && !isChecked)
        {
            CheckCurrentUnlockedTower();
            isChecked = true;
        }
        else
        {
            Debug.Log("Nic tym razem");
        }
    }
    void CheckCurrentUnlockedTower()
    {
        foreach(GameObject enemyButton in enemyButtons)
        {
            if (enemyButton != null)
            {
                if(enemyButton.activeSelf == false)
                {
                    enemyButton.SetActive(true);
                    break;
                }
            }
        }
    }
}
