using UnityEngine;
using Entitas;

[Game]
public class ObstacleCollisionComponent : IComponent
{
    public GameObject collisionObject;
    public GameObject collisionSource;
}
