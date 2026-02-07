using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;       // Prefab del enemigo
    public Vector3 spawnPosition;        // Donde aparecerá el siguiente enemigo
    public RespawnUI respawnUI;

    [Header("Drop que suelta este enemigo")]
    public GameObject dropPrefab;

    

    

    public void TakeDamage()
    {
        // Aquí podés reproducir animación de muerte primero si querés
        print("matoAlenemigo");
       
        SpawnDrop(); // <-- agregamos esto para que suelte moneda/llave
        print("aumento mi numero de enemigos matados");
        GameManager.instance.EnemyDied();
        respawnUI.Show();      
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
        }
    }

   

    void SpawnDrop()
    {
        if (dropPrefab != null)
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
    }


}
