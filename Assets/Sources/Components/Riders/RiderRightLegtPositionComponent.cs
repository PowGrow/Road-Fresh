using Entitas;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[Game]
public class RiderRightLegPositionComponent : IComponent
{
    public Transform value;
    public TwoBoneIKConstraint constraint;
}
