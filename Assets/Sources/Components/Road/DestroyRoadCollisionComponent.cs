using UnityEngine;
using Entitas;

[Game]
public class DestroyRoadCollisionComponent : IComponent
{
    public GameObject collisionObject;
    public GameObject collisionSource;
}
