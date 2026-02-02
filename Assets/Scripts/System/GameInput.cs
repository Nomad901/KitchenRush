using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private void Awake()
    {
        mInstance = this;

        mPlayerInputActions = new PlayerInputActions();
        mPlayerInputActions.Player.Enable();

        mPlayerInputActions.Player.Interact.performed += Interact_performed;
        mPlayerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        mPlayerInputActions.Player.Pause.performed += Pause_performed;
    }
    private void OnDestroy()
    {
        mPlayerInputActions.Player.Interact.performed -= Interact_performed;
        mPlayerInputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        mPlayerInputActions.Player.Pause.performed -= Pause_performed;

        mPlayerInputActions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mOnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mOnInteractAlternate?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mOnInteract?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 getMovementVector(bool pGetNormalized)
    {
        Vector2 inputVector = mPlayerInputActions.Player.Move.ReadValue<Vector2>();

        if(pGetNormalized)
            inputVector = inputVector.normalized;

        return inputVector;
    }
    public string getBindingKeyText(KeyBindings pKeyBinding)
    {
        switch (pKeyBinding)
        {
            case KeyBindings.MOVE_UP:
                return mPlayerInputActions.Player.Move.bindings[1].ToDisplayString();
            case KeyBindings.MOVE_DOWN:
                return mPlayerInputActions.Player.Move.bindings[2].ToDisplayString();
            case KeyBindings.MOVE_LEFT:
                return mPlayerInputActions.Player.Move.bindings[3].ToDisplayString();
            case KeyBindings.MOVE_RIGHT:
                return mPlayerInputActions.Player.Move.bindings[4].ToDisplayString();
            case KeyBindings.INTERACT:
                return mPlayerInputActions.Player.Interact.bindings[0].ToDisplayString();
            case KeyBindings.INTERACT_ALT:
                return mPlayerInputActions.Player.InteractAlternate.bindings[0].ToDisplayString();
            case KeyBindings.PAUSE:
                return mPlayerInputActions.Player.Pause.bindings[0].ToDisplayString();
        }

        return "";
    }
    public void rebindKey(KeyBindings pKeyBinding)
    {
        mPlayerInputActions.Player.Disable();

        mPlayerInputActions.Player.Move.PerformInteractiveRebinding(1)
            .OnComplete(callback =>
            {
                Debug.Log(callback.action.bindings[1].path);
                Debug.Log(callback.action.bindings[1].overridePath);
                callback.Dispose();
                mPlayerInputActions.Player.Enable();
            })
            .Start();
    }
    public PlayerInputActions getPlayerInputActions()
    {
        return mPlayerInputActions;
    }
    private PlayerInputActions mPlayerInputActions;

    public event EventHandler mOnInteract;
    public event EventHandler mOnInteractAlternate;
    public event EventHandler mOnPauseAction;
    public enum KeyBindings
    { 
        MOVE_UP = 0,
        MOVE_DOWN = 1,
        MOVE_LEFT = 2,
        MOVE_RIGHT = 3,
        INTERACT = 4,
        INTERACT_ALT = 5,
        PAUSE = 6
    };
    public static GameInput mInstance { get; private set; }
}
