using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetRunning(bool isRunning)
    {
        animator.SetBool("IsRunning", isRunning);
    }

    public void PlayHit()
    {
        animator.ResetTrigger("Hit");
        animator.SetTrigger("Hit");
    }
}