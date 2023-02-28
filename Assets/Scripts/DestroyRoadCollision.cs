using Entitas.Unity;
using UnityEngine;

public class DestroyRoadCollision : CollisionBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (HasLinkedEntity(other.gameObject))
        {
            var entity = (GameEntity)other.gameObject.GetEntityLink().entity;
            if (entity.isRoad)
            {
                var collisionEntity = Contexts.sharedInstance.game.CreateEntity();
                collisionEntity.AddDestroyRoadCollision(other.gameObject, gameObject);
            }
        }
    }
}
