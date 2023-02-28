using Entitas.Unity;
using UnityEngine;

public class ObstacleCollision : CollisionBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (HasLinkedEntity(other.gameObject))
        {
            var entity = (GameEntity)other.gameObject.GetEntityLink().entity;
            if (entity.isPlayer)
                entity.isFell = true;
        }
    }
}
