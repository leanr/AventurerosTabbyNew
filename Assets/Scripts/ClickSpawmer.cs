using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnPoints;

    public float spawnDelay = 0.5f; // medio segundo
    private float nextSpawnTime = 0f;

    public LayerMask blockedLayer; // objetos que NO deben permitir spawn


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextSpawnTime)
        {

            if (ClickIsBlocked()) return;  // si tocó moneda u otro objeto, no spawnea

            Spawn();
            nextSpawnTime = Time.time + spawnDelay;
        }
    }

    void Spawn()
    {
        if (spawnPoints.Length == 0) return; // seguridad

        int index = Random.Range(0, spawnPoints.Length);
        Transform chosenPoint = spawnPoints[index];

        Instantiate(
            prefab,
            chosenPoint.position,
            chosenPoint.rotation
        );
    }

    bool ClickIsBlocked()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 1f, blockedLayer);

        return hit.collider != null;
    }
}