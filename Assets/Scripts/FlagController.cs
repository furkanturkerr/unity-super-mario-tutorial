using UnityEngine;

public class FlagController : MonoBehaviour
{
    public Transform flag;       // Sahneden Bayrak nesnesini buraya sürükle
    public float speed = 3f;     // Bayraðýn inme hýzý

    private Vector3 endPosition; // Hedef pozisyon (bayrak nereye insin?)
    private bool moveFlag = false;

    private void Start()
    {
        // Bayraðýn ineceði pozisyonu hesapla (örnek: 2 birim aþaðý)
        endPosition = new Vector3(flag.position.x, flag.position.y - 6f, flag.position.z);
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        // Mario çarptýysa animasyonu baþlat
        if (temas.CompareTag("Player"))
        {
            moveFlag = true;
        }
    }

    private void Update()
    {
        // Eðer çarpýþma olduysa bayraðý indir
        if (moveFlag)
        {
            flag.position = Vector3.MoveTowards(flag.position, endPosition, speed * Time.deltaTime);
        }
    }
}
