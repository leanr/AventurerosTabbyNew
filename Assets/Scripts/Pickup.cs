using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum PickupType { Coin, Key }
    public PickupType type;

    private void OnMouseDown() // clic sobre el objeto
    {
        if (type == PickupType.Coin)
            GameManager.instance.AddCoins(1);
        else if (type == PickupType.Key)
            GameManager.instance.AddKeys(1);

        Destroy(gameObject);
    }
}