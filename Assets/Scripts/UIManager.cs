using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using TMPro; // importante


public class UIManager : MonoBehaviour
{

    public TMP_Text coinsText;
    public TMP_Text keysText;
    public TMP_Text playerDeathsText;
    public TMP_Text enemyDeathsText;


    void Update()
    {
        coinsText.text = GameManager.instance.coins.ToString();
        keysText.text = GameManager.instance.keys.ToString();
        playerDeathsText.text = GameManager.instance.playerDeaths.ToString();
        enemyDeathsText.text = GameManager.instance.enemyDeaths.ToString();
    }


    public void ResetScene()
    {
        // Reinicia la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Adventurers");

        // Opcional: si pausaste el juego con Time.timeScale
        Time.timeScale = 1f;
    }
}