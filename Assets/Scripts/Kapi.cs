using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Kapý : MonoBehaviour
{
    public GameObject resultPanel;               // Oyun sonunda açýlacak sonuç paneli
    public TextMeshProUGUI coinText;             // Toplanan coin sayýsýný göstermek için TextMeshPro text nesnesi
    public TextMeshProUGUI timeText;             // Geçen süreyi göstermek için TextMeshPro text nesnesi

    private void OnTriggerEnter2D(Collider2D temas) // 2D çarpýþma algýlayýcýsý, baþka nesne ile temas ettiðinde çalýþýr
    {
        if (temas.CompareTag("Player"))         // Eðer temas eden nesne "Player" tag'ine sahipse
        {
            Zaman.Instance.ZamanDur();           // Zaman sayacýný durdurur

            resultPanel.SetActive(true);         // Sonuç panelini görünür yapar

            // Coin sayýsýný ve geçen süreyi ekranda gösterir
            coinText.text = "Toplanan Coin: " + CoinManager.Instance.coinCount;
            timeText.text = "Geçen Süre: " + Mathf.RoundToInt(Zaman.Instance.gecenSure) + " saniye";
        }
    }

    public void RestartLevel()                   // Oyunu yeniden baþlatýr
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Aktif sahneyi tekrar yükler
    }

    public void ExitGame()                        // Oyunu kapatýr (build edildiðinde çalýþýr)
    {
        Application.Quit();
    }
}
