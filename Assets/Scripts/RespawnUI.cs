using UnityEngine;

public class RespawnUI : MonoBehaviour
{
    public EnemySpawner spawner;



    void Start()
    {
       // Hide(); // oculta el panel al iniciar
    }

    public void Show()
    {
        //gameObject.SetActive(true);
        
        Time.timeScale = 0f; // pausa el juego
  

    }

    public void Hide()
    {
        //gameObject.SetActive(false);
        Time.timeScale = 1f;

       
    }

    public void SpawnEnemyA()
    {

        spawner.SpawnEnemy(0);
        Hide();
    }

    public void SpawnEnemyB()
    {
        spawner.SpawnEnemy(1);
        Hide();
    }

    public void SpawnEnemyC()
    {
        spawner.SpawnEnemy(2);
        Hide();
    }
}