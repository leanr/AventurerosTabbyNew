using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint; // referencia directa

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
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