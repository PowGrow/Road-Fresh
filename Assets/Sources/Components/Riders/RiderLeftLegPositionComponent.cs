using Entitas;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[Game]
public class RiderLeftLegPositionComponent : IComponent
{
    public Transform value;
    public TwoBoneIKConstraint constraint;
}
