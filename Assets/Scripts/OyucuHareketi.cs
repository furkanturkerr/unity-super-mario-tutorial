using Unity.Mathematics;
using UnityEngine;

public class OyucuHareketi : MonoBehaviour
{
    private new Camera camera; // Ana kameray� referans almak i�in
    private new Rigidbody2D rigidbody; // 2D fizik bile�eni
    private Animator animator; // Animasyon kontrol� i�in

    private Vector2 vector2; // Hareket vekt�r�
    private float inputAxis; // Klavyeden gelen yatay giri� de�eri

    public float harakethizi = 8f; // Yatay hareket h�z�
    public float maxziplama = 5f; // Z�plama y�ksekli�i
    public float maxziplamasuresi = 1f; // Maksimum z�plama s�resi

    // Maksimum y�ksekli�e ula�mak i�in gereken ilk h�z (fizik form�l�)
    public float ziplamakuvveti => (2f * maxziplama) / (maxziplamasuresi / 2f);

    // Maksimum y�kseklik ve s�reye g�re hesaplanan yer�ekimi
    public float gravity => (-2f * maxziplama) / Mathf.Pow((maxziplamasuresi / 2f), 2);

    public bool yerde { get; private set; } // Karakter yerde mi?
    public bool havada { get; private set; } // Karakter havada m�?

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody2D bile�enini al
        camera = Camera.main; // Ana kameray� al
        animator = GetComponent<Animator>(); // Animator bile�enini al
    }

    private void Update()
    {
        YatayHaraket(); // Klavyeden sa�/sol giri�ine g�re hareket ettir

        yerde = rigidbody.Raycast(Vector2.down); // Yerde mi?

        if (yerde)
            yerdehareket(); // Z�plama kontrol�

        yercekimiuygula(); // Yer�ekimi uygula

        // === AN�MASYONLAR ===
        bool kosuyorMu = Mathf.Abs(inputAxis) > 0.1f;
        animator.SetBool("isRunning", kosuyorMu);
        animator.SetBool("zipla", !yerde);

        // Y�n �evirme
        if (inputAxis > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (inputAxis < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }


    // Yerdeyken z�plama kontrol�
    private void yerdehareket()
    {
        vector2.y = Mathf.Max(vector2.y, 0f); // Yukar� y�nl� h�z s�f�r�n alt�na inmesin
        havada = vector2.y > 0f;

        if (Input.GetButtonDown("Jump"))
        {
            vector2.y = ziplamakuvveti; // Yukar�ya z�plat
            havada = true;
        }
    }

    // Yer�ekimi uygulama i�lemi
    private void yercekimiuygula()
    {
        bool falling = vector2.y < 0f || !Input.GetButton("Jump"); // D���yor mu veya z�plama tu�u b�rak�ld� m�?
        float multiplier = falling ? 2f : 1f; // D��erken daha h�zl� �ek (daha do�al g�r�n�m)

        vector2.y += gravity * multiplier * Time.deltaTime; // Yer�ekimini uygula
        vector2.y = Mathf.Max(vector2.y, gravity / 2f); // D���� h�z�n� s�n�rlamak i�in
    }

    // Yatay hareket (sa�/sol)
    private void YatayHaraket()
    {
        inputAxis = Input.GetAxis("Horizontal"); // A ve D tu�lar�, ok tu�lar�
        vector2.x = Mathf.MoveTowards(vector2.x, inputAxis * harakethizi, harakethizi * Time.deltaTime);
    }

    // Fizik hesaplamalar�n� burada yapar�z
    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += vector2 * Time.fixedDeltaTime;

        // Kamera s�n�rlar� d���na ��kmas�n diye konumu s�n�rl�yoruz
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rigidbody.MovePosition(position); // Yeni pozisyona ta��
    }
}
