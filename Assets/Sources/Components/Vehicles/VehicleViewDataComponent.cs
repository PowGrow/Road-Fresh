using Entitas;
using UnityEngine;

[Game]
public class VehicleViewDataComponent : IComponent
{
    public float Speed;
    public float RotationSpeed;
    public Transform BodyTransform;
    public Transform SteeringWheelTransform;
    public Transform FrontWheelTransform;
    public Transform BackWheelTransform;
}
