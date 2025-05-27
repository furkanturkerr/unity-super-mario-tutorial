using Unity.Mathematics;
using UnityEngine;

public class OyucuHareketi : MonoBehaviour
{
    private new Camera camera; // Ana kamerayý referans almak için
    private new Rigidbody2D rigidbody; // 2D fizik bileþeni
    private Animator animator; // Animasyon kontrolü için

    private Vector2 vector2; // Hareket vektörü
    private float inputAxis; // Klavyeden gelen yatay giriþ deðeri

    public float harakethizi = 8f; // Yatay hareket hýzý
    public float maxziplama = 5f; // Zýplama yüksekliði
    public float maxziplamasuresi = 1f; // Maksimum zýplama süresi

    // Maksimum yüksekliðe ulaþmak için gereken ilk hýz (fizik formülü)
    public float ziplamakuvveti => (2f * maxziplama) / (maxziplamasuresi / 2f);

    // Maksimum yükseklik ve süreye göre hesaplanan yerçekimi
    public float gravity => (-2f * maxziplama) / Mathf.Pow((maxziplamasuresi / 2f), 2);

    public bool yerde { get; private set; } // Karakter yerde mi?
    public bool havada { get; private set; } // Karakter havada mý?

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Rigidbody2D bileþenini al
        camera = Camera.main; // Ana kamerayý al
        animator = GetComponent<Animator>(); // Animator bileþenini al
    }

    private void Update()
    {
        YatayHaraket(); // Klavyeden sað/sol giriþine göre hareket ettir

        yerde = rigidbody.Raycast(Vector2.down); // Yerde mi?

        if (yerde)
            yerdehareket(); // Zýplama kontrolü

        yercekimiuygula(); // Yerçekimi uygula

        // === ANÝMASYONLAR ===
        bool kosuyorMu = Mathf.Abs(inputAxis) > 0.1f;
        animator.SetBool("isRunning", kosuyorMu);
        animator.SetBool("zipla", !yerde);

        // Yön çevirme
        if (inputAxis > 0.01f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (inputAxis < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
    }


    // Yerdeyken zýplama kontrolü
    private void yerdehareket()
    {
        vector2.y = Mathf.Max(vector2.y, 0f); // Yukarý yönlü hýz sýfýrýn altýna inmesin
        havada = vector2.y > 0f;

        if (Input.GetButtonDown("Jump"))
        {
            vector2.y = ziplamakuvveti; // Yukarýya zýplat
            havada = true;
        }
    }

    // Yerçekimi uygulama iþlemi
    private void yercekimiuygula()
    {
        bool falling = vector2.y < 0f || !Input.GetButton("Jump"); // Düþüyor mu veya zýplama tuþu býrakýldý mý?
        float multiplier = falling ? 2f : 1f; // Düþerken daha hýzlý çek (daha doðal görünüm)

        vector2.y += gravity * multiplier * Time.deltaTime; // Yerçekimini uygula
        vector2.y = Mathf.Max(vector2.y, gravity / 2f); // Düþüþ hýzýný sýnýrlamak için
    }

    // Yatay hareket (sað/sol)
    private void YatayHaraket()
    {
        inputAxis = Input.GetAxis("Horizontal"); // A ve D tuþlarý, ok tuþlarý
        vector2.x = Mathf.MoveTowards(vector2.x, inputAxis * harakethizi, harakethizi * Time.deltaTime);
    }

    // Fizik hesaplamalarýný burada yaparýz
    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += vector2 * Time.fixedDeltaTime;

        // Kamera sýnýrlarý dýþýna çýkmasýn diye konumu sýnýrlýyoruz
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rigidbody.MovePosition(position); // Yeni pozisyona taþý
    }
}
