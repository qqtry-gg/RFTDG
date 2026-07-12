using System.Collections;
using UnityEngine;

public class LevelLoaderScript : MonoBehaviour
{
    [SerializeField] Animator Transition;
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
