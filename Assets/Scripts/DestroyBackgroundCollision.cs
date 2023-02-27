using Entitas.Unity;
using UnityEngine;

public class DestroyBackgroundCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var entity = GetLinkedEntity(other.gameObject);
        if (entity != null && entity.isBackground)
        {
           var collisionEntity = Contexts.sharedInstance.game.CreateEntity();
           collisionEntity.AddDestroyBackgroundCollision(other.gameObject, gameObject);
        }
    }

    private GameEntity GetLinkedEntity(GameObject gameObject)
    {
        return (GameEntity)gameObject.GetEntityLink().entity;
    }
}
