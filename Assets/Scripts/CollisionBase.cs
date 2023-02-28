using Entitas.Unity;
using UnityEngine;

public class CollisionBase : MonoBehaviour
{
    protected bool HasLinkedEntity(GameObject gameObject)
    {
        var entityLink = gameObject.GetEntityLink();
        if (entityLink != null)
            return true;
        return false;
    }
}
