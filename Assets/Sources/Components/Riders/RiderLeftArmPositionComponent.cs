using Entitas;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[Game]
public class RiderLeftArmPositionComponent : IComponent
{
    public Transform value;
    public TwoBoneIKConstraint constraint;
}
