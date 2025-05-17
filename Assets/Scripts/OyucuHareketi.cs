using UnityEngine;

public class OyucuHareketi : MonoBehaviour
{
    private new Camera camera;
    private new Rigidbody2D rigidbody;

    public float harakethizi = 8f;
    private Vector2 vector2;

    private float �nputaxis;
    private float maxziplama = 5f;
    private float maxziplamasuresi = 1f;

    public float ziplamakuvveti => (2f * maxziplamasuresi) / (maxziplama / 2f);
    public float gravity => (-2f * maxziplamasuresi) / Mathf.Pow((maxziplama / 2f), 2);

    public bool yerde {  get; private set; }
    public bool havada { get; private set; }

    public void Awake() //Start() metodundan �nce �al���r.
    {
        rigidbody = GetComponent<Rigidbody2D>();   
        camera = Camera.main;
    }

    public void Update()
    {
        YatayHaraket();
    }

    public void YatayHaraket()
    {
        �nputaxis = Input.GetAxis("Horizontal");
        vector2.x = Mathf.MoveTowards(vector2.x, �nputaxis * harakethizi, harakethizi * Time.deltaTime);
        //Bu sat�r sayesinde, karakterin yatay h�z� (x ekseni) aniden de�i�mek yerine hedef h�za do�ru yumu�ak�a ilerliyor.
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position += vector2 * Time.fixedDeltaTime;

        //Kamrean�n s�n�rlar� d���na ��kmas�n� engelliyoruz
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x + 0.5f);

        rigidbody.MovePosition(position);

        //Bu i�lem sayesinde pozisyon her frame�de sabit bir h�zla g�ncellenir.
    }
}
