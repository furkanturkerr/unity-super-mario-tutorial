using System.Xml.Serialization;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate()//Ge� g�ncelleme
    {
        //Burada kamera oyuncuyu takip ediyor
        Vector3 cameraposition = transform.position;
        cameraposition.x = Mathf.Max(cameraposition.x, player.position.x); // kamrea sa�a giderken geliyor ama sola giderken gelmiyor
        transform.position = cameraposition;


    }
}
