using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        // Hareket
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        // Ko�ma animasyonu
        anim.SetBool("isRunning", move != 0);

        // Z�plama
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 10f); // Z�plama kuvveti
            anim.SetBool("isJumping", true);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere bas�nca z�plama animasyonunu durdur
        if (collision.contacts[0].normal.y > 0.5f)
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
    }
}
