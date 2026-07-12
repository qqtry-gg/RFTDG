using System.Collections;
using UnityEngine;

public class MenuAnimationScript : MonoBehaviour
{
    [SerializeField] GameObject levelMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OpenMenu()
    {
        levelMenu.SetActive(true);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f);
    }
    public void CloseMenu()
    {
        LeanTween.scale(gameObject, new Vector3(0.01f, 0.01f, 0.01f), 0.5f).setOnComplete(() => { levelMenu.SetActive(false); });
    } 
}
