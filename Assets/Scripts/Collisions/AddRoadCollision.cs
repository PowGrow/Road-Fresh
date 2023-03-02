using Entitas.Unity;
using UnityEngine;

namespace RoadFresh.GameLoop.Collisions
{
    public class AddRoadCollision : CollisionBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (HasLinkedEntity(other.gameObject))
            {
                var entity = (GameEntity)other.gameObject.GetEntityLink().entity;
                if (entity != null && entity.isRoad)
                {
                    var collisionEntity = Contexts.sharedInstance.game.CreateEntity();
                    collisionEntity.AddAddRoadCollision(other.gameObject, gameObject);
                }
            }
        }
    }
}
