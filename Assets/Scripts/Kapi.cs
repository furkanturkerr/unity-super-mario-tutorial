using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Kap� : MonoBehaviour
{
    public GameObject resultPanel;               // Oyun sonunda a��lacak sonu� paneli
    public TextMeshProUGUI coinText;             // Toplanan coin say�s�n� g�stermek i�in TextMeshPro text nesnesi
    public TextMeshProUGUI timeText;             // Ge�en s�reyi g�stermek i�in TextMeshPro text nesnesi

    private void OnTriggerEnter2D(Collider2D temas) // 2D �arp��ma alg�lay�c�s�, ba�ka nesne ile temas etti�inde �al���r
    {
        if (temas.CompareTag("Player"))         // E�er temas eden nesne "Player" tag'ine sahipse
        {
            Zaman.Instance.ZamanDur();           // Zaman sayac�n� durdurur

            resultPanel.SetActive(true);         // Sonu� panelini g�r�n�r yapar

            // Coin say�s�n� ve ge�en s�reyi ekranda g�sterir
            coinText.text = "Toplanan Coin: " + CoinManager.Instance.coinCount;
            timeText.text = "Ge�en S�re: " + Mathf.RoundToInt(Zaman.Instance.gecenSure) + " saniye";
        }
    }

    public void RestartLevel()                   // Oyunu yeniden ba�lat�r
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Aktif sahneyi tekrar y�kler
    }

    public void ExitGame()                        // Oyunu kapat�r (build edildi�inde �al���r)
    {
        Application.Quit();
    }
}
