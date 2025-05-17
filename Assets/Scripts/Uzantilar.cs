using UnityEngine;

public static class Uzantilar
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
    }
}
