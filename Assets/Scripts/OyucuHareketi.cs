using Unity.Mathematics;
using UnityEngine;

public class OyucuHareketi : MonoBehaviour
{
    private new Camera camera;
    private new Rigidbody2D rigidbody;

    private Vector2 vector2;
    private float �nputaxis;
    
    public float harakethizi = 8f;
    public float maxziplama = 5f;
    public float maxziplamasuresi = 1f;

    public float ziplamakuvveti => (2f * maxziplama) / (maxziplamasuresi / 2f);
    public float gravity => (-2f * maxziplama) / Mathf.Pow((maxziplamasuresi / 2f), 2);

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

        yerde = rigidbody.Raycast(Vector2.down);//e�er yere de�iyorsa
        if (yerde)
        {
            yerdehareket();
        }

        yercekimiuygula();  
    }

    public void yerdehareket()
    {
        vector2.y = Mathf.Max(vector2.y, 0f);
        havada = vector2.y > 0f;

        if (Input.GetButtonDown("Jump"))
        {
            vector2.y = ziplamakuvveti;
            havada = true;
        }
    }

    public void yercekimiuygula()
    {
        bool falling = vector2.y < 0f || !Input.GetButton("Jump");
        float multiplier = falling ? 2f : 1f;

        vector2.y += gravity * multiplier * Time.deltaTime;
        vector2.y = Mathf.Max(vector2.y, gravity / 2f);
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
