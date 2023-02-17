using Entitas;
using Entitas.Unity;
using UnityEngine;

public class RigidbodyViewComponent : MonoBehaviour
{
    private Rigidbody _rigidBody;
    private Animator _animator;
    private Contexts _contexts;
    private VelocityComponent _velocity;
    private SpeedComponent _speed;
    private RotationSpeedComponent _rotationSpeed;
    private RotationComponent _rotation;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _rigidBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        var entity = gameObject.GetEntityLink().entity;
        _velocity = (VelocityComponent)entity.GetComponent((GameComponentsLookup.Velocity));
        _speed = (SpeedComponent)entity.GetComponent((GameComponentsLookup.Speed));
        _rotation = (RotationComponent)entity.GetComponent((GameComponentsLookup.Rotation));
        _rotationSpeed = (RotationSpeedComponent)entity.GetComponent((GameComponentsLookup.RotationSpeed));
    }
    private void FixedUpdate()
    {
        var deltaRotation = Quaternion.Euler(new Vector3(0, _rotation.value.y, 0) * _rotationSpeed.value * Time.fixedDeltaTime);
        var deltaPosition = transform.forward * _velocity.value.z * _speed.value * Time.fixedDeltaTime;

        _rigidBody.MoveRotation(_rigidBody.rotation * deltaRotation);
        _rigidBody.MovePosition(_rigidBody.position + deltaPosition);

        _animator.SetFloat("VelocityZ", _velocity.value.z);
        _animator.SetFloat("RotationY", _rotation.value.y);
    }
}
