using Entitas.Unity;
using UnityEngine;

public class AddBackgroundCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var entity = GetLinkedEntity(other.gameObject);
        if (entity != null && entity.isBackground)
        {
            var collisionEntity = Contexts.sharedInstance.game.CreateEntity();
            collisionEntity.AddAddBackgroundCollision(other.gameObject, gameObject);
        }
    }

    private GameEntity GetLinkedEntity(GameObject gameObject)
    {
        var entityLink = gameObject.GetEntityLink();
        return (GameEntity)entityLink.entity;
    }
}
