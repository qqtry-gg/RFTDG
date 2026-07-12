using System.Collections;
using UnityEngine;

public class LevelLoaderScript : MonoBehaviour
{
    [SerializeField] Animator Transition;
    private void Start()
    {
        SceneChanged();
    }
    public void SceneChanged()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        Transition.SetTrigger("Start");

        yield return new WaitForSeconds(1f);
    }
}
