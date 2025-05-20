using UnityEngine;
using UnityEngine.SceneManagement;

public class Siyah : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // CoinManager içindeki coinCount'u sýfýrla
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.coinCount = 0;
            }

            // Sahneyi yeniden yükle (baþtan baþlat)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
