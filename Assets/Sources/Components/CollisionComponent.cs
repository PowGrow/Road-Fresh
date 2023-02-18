using Entitas;
using UnityEngine;

[Game]
public class CollisionComponent : IComponent
{
    public GameObject collisionSourceObject;
    public GameObject collisionObject;
}
