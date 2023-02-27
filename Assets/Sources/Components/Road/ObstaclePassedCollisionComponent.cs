using UnityEngine;
using Entitas;

[Game]
public class ObstaclePassedCollisionComponent : IComponent
{
    public GameObject collisionObject;
    public GameObject collisionSource;
}
