using UnityEngine;

public class Zaman : MonoBehaviour
{
    public static Zaman Instance; // Bu sýnýfýn tekil (singleton) örneðini tutar
    public float gecenSure = 0f; // Geçen süreyi saniye cinsinden tutar
    public bool zamanAktif = true; // Zamanýn aktif olup olmadýðýný kontrol eder

    void Awake()
    {
        if (Instance == null) Instance = this;  // Eðer daha önce bir örnek yoksa bu örneði atar
        else Destroy(gameObject);               // Eðer zaten bir örnek varsa, bu nesneyi yok eder (singleton kalmasý için)
    }

    void Update()
    {
        if (zamanAktif)                         // Eðer zaman aktifse
            gecenSure += Time.deltaTime;       // geçen süreye, geçen frame süresini ekler (zamana sayar)
    }

    public void ZamanDur()
    {
        zamanAktif = false;                     // Zamaný durdurur (sayacý durdurur)
    }
}
