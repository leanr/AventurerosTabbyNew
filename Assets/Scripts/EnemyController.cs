using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;       // Prefab del enemigo
    public Vector3 spawnPosition;        // Donde aparecerá el siguiente enemigo
    public RespawnUI respawnUI;

    [Header("Drop que suelta este enemigo")]
    public GameObject dropPrefab;

    bool puedoInvocar = false;






    public void TakeDamage()
    {
        // Aquí podés reproducir animación de muerte primero si querés
        print("matoAlenemigo");
       
        SpawnDrop(); // <-- agregamos esto para que suelte moneda/llave
        print("aumento mi numero de enemigos matados");
        GameManager.instance.EnemyDied();
        respawnUI.Show();

        /*
        if (playerAnimator != null)
        {
            print("el playeranimator va bien");
            playerAnimator.PlayEnemyDeath();
        }
   
        */
        Destroy(gameObject);



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
           // playerAnimator.PlayEnemyDeath();
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


      
    }




}
