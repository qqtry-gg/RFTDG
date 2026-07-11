using UnityEngine;
using System.Collections;

public class DisableObejct : MonoBehaviour
{
    [SerializeField] GameObject RealMenu;
    public void DisableObjectEND()
    {
        gameObject.SetActive(false);
        if (RealMenu != null ) RealMenu.SetActive(false);
    }
    public void DisableObject()
    {
        transform.localScale = Vector3.one * 0.05f;
        gameObject.SetActive(false);
    }

}
