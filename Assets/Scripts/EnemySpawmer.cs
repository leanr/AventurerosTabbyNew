using UnityEngine;

public class    EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Prefab del enemigo
    public Transform spawnPointA;     // Lugar exacto donde aparecerá
    public Transform spawnPointB;
    public Transform spawnPointC;

    public Transform spawnPoint;
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
                spawnPoint = spawnPointA;

                break;
            case 1:
                enemyToSpawn = enemyB;
                spawnPoint = spawnPointB;

                break;
            case 2:
                enemyToSpawn = enemyC;
                spawnPoint = spawnPointC;

                break;
        }
        
        

        if (enemyToSpawn != null)
        {
            Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
        }
    }


}