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

    public void TryPlayHit(GameObject enemyObj)
    {
        EnemyController enemy = enemyObj.GetComponent<EnemyController>();

        // Si el enemigo no existe o está muriendo, no reproducir animación
        if (enemy == null || enemy.isDying) return;

        // Si el enemigo puede recibir daño, reproducimos el Hit
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

    public void PlayEnemyDeath()
    {
        animator.ResetTrigger("DeathEnemy");
        animator.SetTrigger("DeathEnemy");
    }


}