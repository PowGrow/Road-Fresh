using Entitas.Unity;
using UnityEngine;

public class RigidbodyViewComponent : MonoBehaviour
{
    private Animator _animator;
    private VelocityInputComponent _velocityInput;
    private RotationInputComponent _rotationInput;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        var entity = gameObject.GetEntityLink().entity;
        _velocityInput = (VelocityInputComponent)entity.GetComponent((GameComponentsLookup.VelocityInput));
        _rotationInput = (RotationInputComponent)entity.GetComponent((GameComponentsLookup.RotationInput));
    }
    private void Update()
    {
        _animator.SetFloat("VelocityZ", _velocityInput.value.z);
        _animator.SetFloat("RotationY", _rotationInput.value);
        Debug.Log("velocity: " + _velocityInput.value.z + " rotation: " + _rotationInput.value);
    }
}
