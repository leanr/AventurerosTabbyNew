using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement movement;
    PlayerAnimator playerAnimator;

    bool isHit;

    void Awake()
    {
        movement = GetComponent<Movement>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    void Update()
    {
        // Solo actualiza run si NO está en hit
        if (!isHit)
        {
            playerAnimator.SetRunning(movement.canMove);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("SkeletonRogue"))

           
        {
            isHit = true;
            movement.canMove = false;
            print("estoy chocando");
            playerAnimator.PlayHit();
        }
    }

    // Llamado por Animation Event al final del hit
    public void OnHitFinished()
    {
        isHit = false;
        movement.canMove = true;
    }
}