using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public Transform[] path;

    public Transform startPoint;
    private void Awake()
    {
        main = this;
    }
}
