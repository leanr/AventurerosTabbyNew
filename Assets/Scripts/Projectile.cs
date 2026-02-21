using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        transform.Translate(0, 0, -0.05f, Space.World);

        if (CompareTag("Axe"))
        {
            transform.Rotate(0, 0, 500 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mage"))
        {
            Destroy(gameObject);
        }

    }


}
