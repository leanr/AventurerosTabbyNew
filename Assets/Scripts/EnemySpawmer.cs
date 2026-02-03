using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Prefab del enemigo
    public Transform spawnPoint;     // Lugar exacto donde aparecerá

    // Llamar cuando quieras generar un enemigo

    public GameObject enemyA;
    public GameObject enemyB;
    public GameObject enemyC;



    public void SpawnEnemy(int enemyType)
    {

        GameObject enemyToSpawn = null;


        switch (enemyType)
        {
            case 0:
                enemyToSpawn = enemyA;
                break;
            case 1:
                enemyToSpawn = enemyB;
                break;
            case 2:
                enemyToSpawn = enemyC;
                break;
        }

        if (enemyToSpawn != null)
        {
            Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
        }
    }
}