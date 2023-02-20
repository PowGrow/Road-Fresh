using Entitas;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[Game]
public class RiderRightArmPositionComponent : IComponent
{
    public Transform value;
    public TwoBoneIKConstraint constraint;
}
