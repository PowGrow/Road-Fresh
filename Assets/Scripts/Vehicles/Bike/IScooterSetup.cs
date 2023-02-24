using UnityEngine;

public interface IScooterSetup
{
    public float Speed { get;}
    public Transform Body { get; }
    public Transform SteeringWheel { get; }
    public Transform FrontWheelView { get; }
    public Transform RearWheelView { get; }
    public WheelCollider FrontWheelCollider { get; }
    public WheelCollider RearWheelCollider { get; }
    public Material BaseMaterial { get; }
}
