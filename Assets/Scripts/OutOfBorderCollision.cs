using Entitas.Unity;
using UnityEngine;

public class OutOfBorderCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var entity = GetLinkedEntity(other.gameObject);
        if (entity != null && entity.isPlayer)
            entity.isOutOfBorder = true;
    }

    private GameEntity GetLinkedEntity(GameObject gameObject)
    {
        var entityLink = gameObject.GetEntityLink();
        return (GameEntity)entityLink.entity;
    }
}
