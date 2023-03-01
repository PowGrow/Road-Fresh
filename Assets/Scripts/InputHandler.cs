using UnityEngine;
using UnityEngine.InputSystem;
using Gyroscope = UnityEngine.InputSystem.Gyroscope;

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
        _inputActions.Player.Strafe.performed += callbackContext => SetStrafe(callbackContext.ReadValue<float>());
        _inputActions.Player.Strafe.canceled += callbackContext => StopStrafe();
        _inputActions.Player.Beep.performed += callbackContext => SetBeep();
        _inputActions.Player.Beep.canceled += callbackContext => StopBeep();
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    private void SetStrafe(float direction)
    {
        _contexts.game.ReplaceStrafeInput(direction);
    }

    private void StopStrafe()
    {
        _contexts.game.ReplaceStrafeInput(0);
    }

    private void SetBeep()
    {
        _contexts.game.ReplaceBeep(true);
    }

    private void StopBeep()
    {
        _contexts.game.ReplaceBeep(false);
    }

}
