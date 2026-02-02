using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;

    public float spawnDelay = 0.5f; // medio segundo
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void Spawn()
    {
        Instantiate(
            prefab,
            spawnPoint.position,
            spawnPoint.rotation
        );
    }
}