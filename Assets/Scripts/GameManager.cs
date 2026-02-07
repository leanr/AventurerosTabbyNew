using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    [Header("Contadores de recolección")]
    public int coins = 0;
    public int keys = 0;

    [Header("Contadores de muertes")]
    public int playerDeaths = 0;
    public int enemyDeaths = 0;

    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins: " + coins);
    }

    public void AddKeys(int amount)
    {
        keys += amount;
        Debug.Log("Keys: " + keys);
    }

    public void PlayerDied()
    {
        playerDeaths++;
        Debug.Log("Player Deaths: " + playerDeaths);
    }

    public void EnemyDied()
    {
        enemyDeaths++;
        Debug.Log("Enemy Deaths: " + enemyDeaths);
    }
}