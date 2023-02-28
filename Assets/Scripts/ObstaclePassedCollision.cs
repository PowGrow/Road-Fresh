using Entitas.Unity;
using UnityEngine;

public class ObstaclePassedCollision : CollisionBase
{
    private void OnTriggerExit(Collider other)
    {
        if (HasLinkedEntity(other.gameObject))
        {
            var entity = (GameEntity)other.gameObject.GetEntityLink().entity;
            if (entity.isPlayer)
            {
                var collisionEntity = Contexts.sharedInstance.game.CreateEntity();
                collisionEntity.AddObstaclePassedCollision(other.gameObject, gameObject);
            }
        }
    }
}
