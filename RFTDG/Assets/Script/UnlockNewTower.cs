using NUnit.Framework;
using UnityEngine;

public class UnlockNewTower : MonoBehaviour
{
    [SerializeField] GameObject towerUnlockedUI;
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
        if (endlessModeManager.wave % 4 == 0 && !isChecked)
        {
            CheckCurrentUnlockedTower();
            towerUnlockedUI.SetActive(true);
            towerUnlockedUI.GetComponent<Animator>().SetTrigger("WaveOver");
            isChecked = true;
        }
        if (endlessModeManager.wave % 10 == 0 && !isChecked && endlessModeManager.wave % 4 != 0)
        {
            CheckCurrentUnlockedTower();
            towerUnlockedUI.SetActive(true);
            towerUnlockedUI.GetComponent<Animator>().SetTrigger("WaveOver");
            isChecked = true;
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
