using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;   // Prefab del enemigo
    public Transform[] spawnPoints;     // Lugar exacto donde aparecerá

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



        if (enemyToSpawn != null && spawnPoints.Length > 0)
        {
            // elegir punto random
            int index = Random.Range(0, spawnPoints.Length);
            Transform chosenPoint = spawnPoints[index];

            Instantiate(enemyToSpawn, chosenPoint.position, Quaternion.identity);
        }
    }


}