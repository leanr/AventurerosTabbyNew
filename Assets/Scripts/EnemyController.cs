using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;       // Prefab del enemigo
    public Vector3 spawnPosition;        // Donde aparecerá el siguiente enemigo
    public RespawnUI respawnUI;

    [Header("Drop que suelta este enemigo")]
    public GameObject dropPrefab;


    PlayerAnimator playerAnimator;

    public EnemySpawner spawner;

    public bool isAlive = true; // true por defecto
    public bool isDying = false;

    void Awake()
    {
        playerAnimator = GetComponentInChildren<PlayerAnimator>();

        if (playerAnimator == null)
            Debug.LogError("NO SE ENCONTRO PlayerAnimator EN EL ENEMIGO");
    }



    public void TakeDamage()
    {

        if (!isAlive || isDying) return; // no hace nada si ya murió o está en muerte
        isAlive = false;
        isDying = true;
        // Aquí podés reproducir animación de muerte primero si querés
        print("matoAlenemigo");
       
        SpawnDrop(); // <-- agregamos esto para que suelte moneda/llave
        print("aumento mi numero de enemigos matados");
        GameManager.instance.EnemyDied();
        respawnUI.Show();


        playerAnimator.PlayEnemyDeath();

        
        //Destroy(gameObject);

        /*
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        */
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mage"))
        {
            //esta logica esta en PlayerController
        }
    }

   

    void SpawnDrop()
    {
        if (dropPrefab != null)
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
    }


    public void DeathFinished()
    {
        print("llegue al final");
        Destroy(gameObject);


        if (spawner != null)
        {
            int enemyType = Random.Range(0, 3); // 0, 1 o 2
            spawner.SpawnEnemy(enemyType);
        }




    }


}
