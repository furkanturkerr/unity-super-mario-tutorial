using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        if (CoinManager.Instance != null)
        {
            CoinManager.Instance.AddCoin(1);
        }
        Destroy(gameObject, 1f);
    }
}
