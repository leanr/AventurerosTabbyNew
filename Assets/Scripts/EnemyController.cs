using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;       // Prefab del enemigo
    public Vector3 spawnPosition;        // Donde aparecerá el siguiente enemigo

    public void TakeDamage()
    {
        // Aquí podés reproducir animación de muerte primero si querés
        Destroy(gameObject); // desaparece al instante
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mage"))
        {
            //esta logica esta en PlayerController
        }
    }

}
