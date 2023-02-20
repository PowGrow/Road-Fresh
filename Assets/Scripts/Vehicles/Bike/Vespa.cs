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
    private Transform frontWheelTransform;
    [SerializeField]
    private Transform backWheelTransform;
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
    public Transform FrontWheel
    {
        get { return frontWheelTransform; }
    }
    public Transform BackWheel
    {
        get { return backWheelTransform; }
    }
    public Material BaseMaterial
    {
        get { return baseMaterial; }
    }
}
