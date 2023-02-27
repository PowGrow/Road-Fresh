using Entitas.Unity;
using UnityEngine;

public class AddRoadCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var entity = GetLinkedEntity(other.gameObject);
        if (entity != null && entity.isRoad)
        {
            var collisionEntity = Contexts.sharedInstance.game.CreateEntity();
            collisionEntity.AddAddRoadCollision(other.gameObject, gameObject);
        }
    }

    private GameEntity GetLinkedEntity(GameObject gameObject)
    {
        var entityLink = gameObject.GetEntityLink();
        return (GameEntity)entityLink.entity;
    }
}
