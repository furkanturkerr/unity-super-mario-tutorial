using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Her yerden ula�mak i�in singleton yapt�m

    public int coinCount = 0; // Ba�lang��ta coin say�s� s�f�r

    public TextMeshProUGUI coinText; // UI'daki coin yaz�s�n� buraya ba�layaca��m

    void Awake()
    {
        // Singleton kontrol�
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI(); // Oyun ba�lad���nda UI'yi s�f�rla
    }

    public void AddCoin(int amount)
    {
        coinCount += amount; // Yeni coin geldi�inde say�y� art�r
        UpdateUI(); // UI'yi g�ncelle
    }

    void UpdateUI()
    {
        // Yaz�y� g�ncelle
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }
}
