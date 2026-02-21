using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;

    public float spawnDelay = 0.5f; // medio segundo
    private float nextSpawnTime = 0f;

    public LayerMask blockedLayer; // objetos que NO deben permitir spawn

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextSpawnTime)
        {

            if (ClickIsBlocked()) return;

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

    bool ClickIsBlocked()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 1f, blockedLayer);

        return hit.collider != null;
    }
}