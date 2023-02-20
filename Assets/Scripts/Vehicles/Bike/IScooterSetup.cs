using UnityEngine;

public interface IScooterSetup
{
    public float Speed { get;}
    public Transform Body { get; }
    public Transform SteeringWheel { get; }
    public Transform FrontWheel { get; }
    public Transform BackWheel { get; }
    public Material BaseMaterial { get; }
}
