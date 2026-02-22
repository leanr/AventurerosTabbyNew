using UnityEngine;

public class ClickSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnDelay = 0.5f;
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextSpawnTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                // Solo spawnear si el collider es BoxCollider (baldosa)
                if (hit.collider is BoxCollider box)
                {
                    // Spawn en el centro de la baldosa que clickeaste
                    Vector3 spawnPos = box.transform.position + box.center;
                    spawnPos.y = prefab.transform.localScale.y / 2f; // encima de la baldosa

                    Instantiate(prefab, spawnPos, Quaternion.identity);
                    nextSpawnTime = Time.time + spawnDelay;
                }
            }
        }
    }
}