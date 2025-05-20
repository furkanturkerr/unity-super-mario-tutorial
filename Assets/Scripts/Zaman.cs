using UnityEngine;

public class Zaman : MonoBehaviour
{
    public static Zaman Instance; // Bu s�n�f�n tekil (singleton) �rne�ini tutar
    public float gecenSure = 0f; // Ge�en s�reyi saniye cinsinden tutar
    public bool zamanAktif = true; // Zaman�n aktif olup olmad���n� kontrol eder

    void Awake()
    {
        if (Instance == null) Instance = this;  // E�er daha �nce bir �rnek yoksa bu �rne�i atar
        else Destroy(gameObject);               // E�er zaten bir �rnek varsa, bu nesneyi yok eder (singleton kalmas� i�in)
    }

    void Update()
    {
        if (zamanAktif)                         // E�er zaman aktifse
            gecenSure += Time.deltaTime;       // ge�en s�reye, ge�en frame s�resini ekler (zamana sayar)
    }

    public void ZamanDur()
    {
        zamanAktif = false;                     // Zaman� durdurur (sayac� durdurur)
    }
}
