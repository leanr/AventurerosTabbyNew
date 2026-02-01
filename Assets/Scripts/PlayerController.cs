using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement movement;
    PlayerAnimator playerAnimator;

    void Awake()
    {
        movement = GetComponent<Movement>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        // Ejemplo: animación de correr
        playerAnimator.PlayRun(movement.canMove);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SkeletonRogue"))
        {
            playerAnimator.PlayHit();
            movement.canMove = false;
        }
    }
}