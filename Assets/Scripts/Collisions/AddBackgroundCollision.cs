using Entitas.Unity;
using UnityEngine;

namespace RoadFresh.GameLoop.Collisions
{
    public class AddBackgroundCollision : CollisionBase
    {
        private void OnTriggerEnter(Collider other)
        {
            if (HasLinkedEntity(other.gameObject))
            {
                var entity = (GameEntity)other.gameObject.GetEntityLink().entity;
                if (entity.isBackground)
                {
                    var collisionEntity = Contexts.sharedInstance.game.CreateEntity();
                    collisionEntity.AddAddBackgroundCollision(other.gameObject, gameObject);
                }
            }
        }
    }
}
