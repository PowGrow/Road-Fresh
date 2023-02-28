using Entitas.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerObstacleCollision : CollisionBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (HasLinkedEntity(other.gameObject))
        {
            var entity = (GameEntity)other.gameObject.GetEntityLink().entity;
            if (entity.isPlayer)
            {
                entity.isFell = true;
                var deerAnimator = GetComponent<Animator>();
                deerAnimator.SetTrigger("Fall");
            }
        }
    }
}
