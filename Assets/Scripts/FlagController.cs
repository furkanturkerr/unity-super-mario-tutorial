using UnityEngine;

public class FlagController : MonoBehaviour
{
    public Transform flag;       // Sahneden Bayrak nesnesini buraya s�r�kle
    public float speed = 3f;     // Bayra��n inme h�z�

    private Vector3 endPosition; // Hedef pozisyon (bayrak nereye insin?)
    private bool moveFlag = false;

    private void Start()
    {
        // Bayra��n inece�i pozisyonu hesapla (�rnek: 2 birim a�a��)
        endPosition = new Vector3(flag.position.x, flag.position.y - 6f, flag.position.z);
    }

    private void OnTriggerEnter2D(Collider2D temas)
    {
        // Mario �arpt�ysa animasyonu ba�lat
        if (temas.CompareTag("Player"))
        {
            moveFlag = true;
        }
    }

    private void Update()
    {
        // E�er �arp��ma olduysa bayra�� indir
        if (moveFlag)
        {
            flag.position = Vector3.MoveTowards(flag.position, endPosition, speed * Time.deltaTime);
        }
    }
}
