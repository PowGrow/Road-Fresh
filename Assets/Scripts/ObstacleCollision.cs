using Entitas.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var entity = GetLinkedEntity(other.gameObject);
        if (entity != null && entity.isPlayer)
            entity.isFell = true;
    }

    private GameEntity GetLinkedEntity(GameObject gameObject)
    {
        var entityLink = gameObject.GetEntityLink();
        return (GameEntity)entityLink.entity;
    }
}
