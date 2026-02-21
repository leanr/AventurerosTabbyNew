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

    public void RecieveHit()
    {
        animator.ResetTrigger("HitAventurero");
        animator.SetTrigger("HitAventurero");
    }

    public void SetDeath()
    {
        animator.ResetTrigger("Death");
        animator.SetTrigger("Death");
    }

    public void StopMovementAnimations()
    {
        // Reinicia cualquier trigger o bool que active correr o hit
        animator.ResetTrigger("Hit");
        animator.ResetTrigger("HitAventurero");
        animator.SetBool("IsRunning", false);
    }
}