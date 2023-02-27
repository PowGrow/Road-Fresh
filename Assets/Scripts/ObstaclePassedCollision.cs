using Entitas.Unity;
using UnityEngine;

public class ObstaclePassedCollision : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        var entity = GetLinkedEntity(other.gameObject);
        if (entity != null && entity.isPlayer)
        {
            var collisionEntity = Contexts.sharedInstance.game.CreateEntity();
            collisionEntity.AddObstaclePassedCollision(other.gameObject, gameObject);
        }
    }

    private GameEntity GetLinkedEntity(GameObject gameObject)
    {
        var entityLink = gameObject.GetEntityLink();
        return (GameEntity)entityLink.entity;
    }
}
