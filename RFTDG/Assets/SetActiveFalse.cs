using UnityEngine;

public class SetActiveFalse : MonoBehaviour
{
    Animator animator;

    private void Start()
    {

        animator = GetComponentInChildren<Animator>();
        gameObject.SetActive(false);
    }
    public void SetAnimatioTrigger()
    {
        animator.SetTrigger("CloseMenu");
    }
}
