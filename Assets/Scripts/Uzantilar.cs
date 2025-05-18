using NUnit.Framework.Internal;
using UnityEngine;

public static class Uzantilar // extension method (geni�letme metodu) 
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
    {
        if (rigidbody.isKinematic)
        {
            return false;
        }

        float redius = 0.25f;
        float distance = 0.375f;

        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, redius, direction, distance, layerMask);
        return hit.collider != null && hit.rigidbody != rigidbody;

        //Bu fonksiyon �rne�in bir karakterin alt�na do�ru Vector2.down y�n�nde tarama yaparak:

            //Yere bas�yor mu?

            //Hemen alt�nda engel var m�?

        //gibi durumlar� tespit etmek i�in kullan�labilir. 
    }
}
 