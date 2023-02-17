using UnityEngine;

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
        _contexts.game.ReplaceVelocityInput(new Vector3(0,0,direction));
    }

    private void StopMotion()
    {
        _contexts.game.ReplaceVelocityInput(Vector3.zero);
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
        //TO-DO INTERACT BUTTON
    }

}
