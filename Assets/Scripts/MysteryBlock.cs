using UnityEngine;

public class MysteryBlock : MonoBehaviour
{
    public GameObject coinPrefab; // Inspector'dan atayacaðýz

    private bool used = false; // Bu kutuya daha önce çarptýk mý?

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!used && collision.CompareTag("Player"))
        {
            SpawnCoin(); // coin çýkart
            used = true; // bir daha çýkmasýn
            Destroy(gameObject, 0.1f); // kendini sahneden kaldýr
        }
    }
    void SpawnCoin()
    {
        if (coinPrefab != null)
        {
            Vector3 spawnPos = transform.position;
            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
            Debug.Log("Coin oluþturuldu!");
        }
        else
        {
            Debug.LogWarning("coinPrefab prefab'ý atanmadý!");
        }
    }

}
