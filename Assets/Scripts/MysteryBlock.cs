using UnityEngine;

public class MysteryBlock : MonoBehaviour
{
    public GameObject coinPrefab; // Inspector'dan atayaca��z

    private bool used = false; // Bu kutuya daha �nce �arpt�k m�?

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!used && collision.CompareTag("Player"))
        {
            SpawnCoin(); // coin ��kart
            used = true; // bir daha ��kmas�n
            Destroy(gameObject, 0.1f); // kendini sahneden kald�r
        }
    }
    void SpawnCoin()
    {
        if (coinPrefab != null)
        {
            Vector3 spawnPos = transform.position;
            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            Debug.Log("Coin olu�turuldu!");
        }
        else
        {
            Debug.LogWarning("coinPrefab prefab'� atanmad�!");
        }
    }

}
