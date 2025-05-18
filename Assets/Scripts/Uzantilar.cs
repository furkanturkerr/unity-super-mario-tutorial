using NUnit.Framework.Internal;
using UnityEngine;

public static class Uzantilar // extension method (geniþletme metodu) 
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

        //Bu fonksiyon örneðin bir karakterin altýna doðru Vector2.down yönünde tarama yaparak:

            //Yere basýyor mu?

            //Hemen altýnda engel var mý?

        //gibi durumlarý tespit etmek için kullanýlabilir. 
    }
}
 