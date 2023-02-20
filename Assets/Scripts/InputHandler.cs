using Entitas.Unity;
using Unity.VisualScripting;
using UnityEngine;
using Entitas;

public class InputHandler : MonoBehaviour
{
    private InputActions _inputActions;
    private Contexts _contexts;

    private void Awake()
    {
        _contexts = Contexts.sharedInstance;
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Player.Movement.performed += callbackContext => SetMotion(callbackContext.ReadValue<float>());
        _inputActions.Player.Movement.canceled += callbackContext => StopMotion();
        _inputActions.Player.Rotation.performed += callbackContext => SetRotation(callbackContext.ReadValue<float>());
        _inputActions.Player.Strafe.performed += callbackContext => SetStrafe(callbackContext.ReadValue<float>());
        _inputActions.Player.Strafe.canceled += callbackContext => StopStrafe();
        _inputActions.Player.Rotation.canceled += callbackContext => StopRotation();
        _inputActions.Player.Interact.performed += callbackConext => Interact();
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void SetMotion(float direction)
    {
        _contexts.game.ReplaceVelocityInput(new Vector3(_contexts.game.velocityInput.value.x,_contexts.game.velocityInput.value.y, direction));
    }

    private void StopMotion()
    {
        _contexts.game.ReplaceVelocityInput(new Vector3(_contexts.game.velocityInput.value.y, _contexts.game.velocityInput.value.y, 0));
    }

    private void SetStrafe(float direction)
    {
        _contexts.game.ReplaceVelocityInput(new Vector3(direction, _contexts.game.velocityInput.value.y, _contexts.game.velocityInput.value.z));
    }

    private void StopStrafe()
    {
        _contexts.game.ReplaceVelocityInput(new Vector3(0,_contexts.game.velocityInput.value.y, _contexts.game.velocityInput.value.z));
    }

    private void SetRotation(float direction)
    {
        _contexts.game.ReplaceRotationInput(direction);
    }

    private void StopRotation()
    {
        _contexts.game.ReplaceRotationInput(0);
    }

    private void Interact()
    {
        var entity = (GameEntity)gameObject.GetEntityLink().entity;
        entity.isTryingToControlVehicle = true;
    }
}
