using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Movement movement;
    PlayerAnimator playerAnimator;
    bool isHit;
    bool isHitAventurero = false;
    bool playerIsDead = false;


    [Header("Vida")]
    public int maxHealth = 100;
    int currentHealth;

    void Awake()
    {
        movement = GetComponent<Movement>();
        playerAnimator = GetComponent<PlayerAnimator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Solo actualiza run si NO está en hit
        if(!isHit && !playerIsDead)
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


        if (collision.gameObject.CompareTag("SkeletonRogue"))


        {
            isHit = true;
            movement.canMove = false;
            print("estoy chocando");
            playerAnimator.PlayHit();
    


        }

        if (collision.gameObject.CompareTag("SkeletonMinion"))


        {
            isHit = true;
            movement.canMove = false;
            print("estoy chocando con el otro enemigo");
            playerAnimator.PlayHit();
           

        }

        if (collision.gameObject.CompareTag("SkeletonWarrior"))


        {
            isHit = true;
            movement.canMove = false;
            print("estoy chocando con el otro enemigo");
            playerAnimator.PlayHit();
      

        }

        if (collision.gameObject.CompareTag("Arrow"))


        {
           // isHitAventurero = true;
           // movement.canMove = false;
            print("me dio la flecha");
            TakeDamage(50); // daño de 1 por golpe

        }
    }

    // Llamado por Animation Event al final del hit
    public void OnHitFinished()
    {
        if (playerIsDead) return;
        print("vuelvo a caminar despues de golpear");
        isHit = false;
        movement.canMove = true;
        playerAnimator.SetRunning(movement.canMove);
    }

    public void RecieveHitFinished()
    {
        if (playerIsDead) return;
        print("vuelvo a caminar despues de recibir golpe");
        isHitAventurero = false;
        movement.canMove = true;
        playerAnimator.SetRunning(movement.canMove);
    }

    public void DoAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, 1f); // 1 = radio del ataque
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("SkeletonRogue"))
            {
                // Llama al TakeDamage del EnemyController
                EnemyController enemy = hit.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage(); // destruye el enemigo
                }
            }

            if (hit.CompareTag("SkeletonMinion"))
            {
                // Llama al TakeDamage del EnemyController
                EnemyController enemy = hit.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage(); // destruye el enemigo
                }
            }


            if (hit.CompareTag("SkeletonWarrior"))
            {
                // Llama al TakeDamage del EnemyController
                EnemyController enemy = hit.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.TakeDamage(); // destruye el enemigo
                }
            }
        }
        


    }

    public void TakeDamage(int damage)
    {
       // if (isHitAventurero) return; // evita daño múltiple en el mismo golpe

        currentHealth -= damage;
        Debug.Log("Vida restante: " + currentHealth);

        isHitAventurero = true;
        movement.canMove = false;
        playerAnimator.RecieveHit();


        if (currentHealth <= 0)
        {
            Die();
            print("empiezo la muerte");
           // Destroy(gameObject, 1f);

        }
    }

    void Die()
    {
        playerIsDead = true;                   // bloquea todo
        movement.canMove = false;         // asegurate de que no pueda moverse
         playerAnimator.StopMovementAnimations();
        playerAnimator.SetDeath();        // dispara animación de muerte
       
    }

    public void DeathFinished()
    {
        Debug.Log("El jugador murió");
       // movement.canMove = false;
        Destroy(gameObject);


        // acá después podemos poner animación de muerte o respawn
    }
}