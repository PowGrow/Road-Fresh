using UnityEngine;
using Entitas;

[Game]
public class ObastacleCollisionComponent : IComponent
{
    public GameObject collisionObject;
    public GameObject collisionSource;
}
