using UnityEngine;
using UnityEngine.SceneManagement;

public class Siyah : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // CoinManager i�indeki coinCount'u s�f�rla
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.coinCount = 0;
            }

            // Sahneyi yeniden y�kle (ba�tan ba�lat)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
