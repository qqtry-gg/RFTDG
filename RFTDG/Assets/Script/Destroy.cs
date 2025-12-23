using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float TimeBeforeDestroy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // Usuwanie obiektu po 0.5s (czas trwania animacji)
        Destroy(gameObject, TimeBeforeDestroy);
    }
}
