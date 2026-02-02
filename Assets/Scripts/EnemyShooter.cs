using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform shootPoint;
    public bool canShoot = true;
    public float fireRate = 3f;

    private float timer;

    void Update()
    {
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
}