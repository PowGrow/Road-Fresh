using UnityEngine;

public sealed class Vespa : MonoBehaviour, IScooterSetup
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Transform bodyTransform;
    [SerializeField]
    private Transform steeringWheelTransform;
    [SerializeField]
    private Transform frontWheelViewTransform;
    [SerializeField]
    private Transform rearWheelViewTransform;
    [SerializeField]
    private WheelCollider frontWheelCollider;
    [SerializeField]
    private WheelCollider rearWheelCollider;
    [SerializeField]
    private Material baseMaterial;
    public float Speed 
    { 
        get { return speed; } 
    }
    public float RotationSpeed
    {
        get { return rotationSpeed; }
    }
    public Transform Body
    {
        get { return bodyTransform; }
    }
    public Transform SteeringWheel
    {
        get { return steeringWheelTransform; }
    }
    public Transform FrontWheelView
    {
        get { return frontWheelViewTransform; }
    }
    public Transform RearWheelView
    {
        get { return rearWheelViewTransform; }
    }
    public WheelCollider FrontWheelCollider
    {
        get { return frontWheelCollider; }
    }
    public WheelCollider RearWheelCollider
    {
        get { return rearWheelCollider; }
    }
    public Material BaseMaterial
    {
        get { return baseMaterial; }
    }
}
