using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Solo métodos públicos que disparan animaciones
    public void PlayHit()
    {
        animator.SetTrigger("hitWithSkeletonRogue");
    }

    public void PlayRun(bool isRunning)
    {
        animator.SetBool("IsRunning", isRunning);
    }
}