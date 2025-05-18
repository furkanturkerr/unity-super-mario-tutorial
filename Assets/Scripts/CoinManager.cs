using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Her yerden ulaþmak için singleton yaptým

    public int coinCount = 0; // Baþlangýçta coin sayýsý sýfýr

    public TextMeshProUGUI coinText; // UI'daki coin yazýsýný buraya baðlayacaðým

    void Awake()
    {
        // Singleton kontrolü
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
        UpdateUI(); // Oyun baþladýðýnda UI'yi sýfýrla
    }

    public void AddCoin(int amount)
    {
        coinCount += amount; // Yeni coin geldiðinde sayýyý artýr
        UpdateUI(); // UI'yi güncelle
    }

    void UpdateUI()
    {
        // Yazýyý güncelle
        if (coinText != null)
            coinText.text = "Coins: " + coinCount;
    }
}
