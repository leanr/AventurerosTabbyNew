using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public bool canShoot = true;
    public float fireRate = 3f;
    public float detectionDistance = 6f; // distancia del raycast
    
    private float timer;

    void Update()
    {
        DetectPlayer();

        if (canShoot == true)
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);
                timer = 0;
            }
        }
        else
        {

        }


    }



    public void StopShooting()
    {
        canShoot = false;
        timer = 0; // evita disparo inmediato
    }

    public void StartShooting()
    {
        canShoot = true;
    }

    void DetectPlayer()
    {
        if (shootPoint == null) return;

        RaycastHit hit;
        float radius = 0.5f;

        // Calculamos dirección hacia el player usando la posición del collider que queremos detectar
        Collider[] hits = Physics.OverlapSphere(shootPoint.position, detectionDistance);
        foreach (var col in hits)
        {
            if (col.CompareTag("Mage"))
            {
                // dirección desde shootPoint hacia el player
                Vector3 direction = (col.transform.position - shootPoint.position).normalized;

                if (Physics.SphereCast(shootPoint.position, radius, direction, out hit, detectionDistance))
                {
                    if (hit.collider.CompareTag("Mage"))
                    {
                        canShoot = true;
                        return;
                    }
                }
            }
        }

        canShoot = false;
    }

    void OnDrawGizmos()
    {
        if (shootPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(shootPoint.position, Vector3.back * detectionDistance);
    }
}