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

        if (PlayerPrefs.HasKey(PLAYER_PREFS_BINDINGS))
            mPlayerInputActions.LoadBindingOverridesFromJson(PlayerPrefs.GetString(PLAYER_PREFS_BINDINGS));

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
            case KeyBindings.GAMEPAD_INTERACT:
                return mPlayerInputActions.Player.Interact.bindings[1].ToDisplayString();
            case KeyBindings.GAMEPAD_INTERACT_ALT:
                return mPlayerInputActions.Player.InteractAlternate.bindings[1].ToDisplayString();
            case KeyBindings.GAMEPAD_PAUSE:
                return mPlayerInputActions.Player.Pause.bindings[1].ToDisplayString();
        }

        return "";
    }
    public void rebindKey(KeyBindings pKeyBinding, Action pOnActionRebound)
    {
        mPlayerInputActions.Player.Disable();

        InputAction inputAction = mPlayerInputActions.Player.Move;
        Int32 bindingIndex = 0;

        switch (pKeyBinding)
        {
            case KeyBindings.MOVE_UP:
                inputAction = mPlayerInputActions.Player.Move;
                bindingIndex = 1;
                break;
            case KeyBindings.MOVE_DOWN:
                inputAction = mPlayerInputActions.Player.Move;
                bindingIndex = 2;
                break;
            case KeyBindings.MOVE_LEFT:
                inputAction = mPlayerInputActions.Player.Move;
                bindingIndex = 3;
                break;
            case KeyBindings.MOVE_RIGHT:
                inputAction = mPlayerInputActions.Player.Move;
                bindingIndex = 4;
                break;
            case KeyBindings.INTERACT:
                inputAction = mPlayerInputActions.Player.Interact;
                bindingIndex = 0;
                break;
            case KeyBindings.INTERACT_ALT:
                inputAction = mPlayerInputActions.Player.InteractAlternate;
                bindingIndex = 0;
                break;
            case KeyBindings.PAUSE:
                inputAction = mPlayerInputActions.Player.Pause;
                bindingIndex = 0;
                break;
            case KeyBindings.GAMEPAD_INTERACT:
                inputAction = mPlayerInputActions.Player.Interact;
                bindingIndex = 1;
                break;
            case KeyBindings.GAMEPAD_INTERACT_ALT:
                inputAction = mPlayerInputActions.Player.InteractAlternate;
                bindingIndex = 1;
                break;
            case KeyBindings.GAMEPAD_PAUSE:
                inputAction = mPlayerInputActions.Player.Pause;
                bindingIndex = 1;
                break;
        }

        inputAction.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(callback =>
            {
                callback.Dispose();
                mPlayerInputActions.Player.Enable();
                pOnActionRebound();

                PlayerPrefs.SetString(PLAYER_PREFS_BINDINGS, mPlayerInputActions.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();
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
        PAUSE = 6,

        GAMEPAD_INTERACT = 7,
        GAMEPAD_INTERACT_ALT = 8,
        GAMEPAD_PAUSE = 9
    };
    private const string PLAYER_PREFS_BINDINGS = "InputBindings";
    public static GameInput mInstance { get; private set; }
}
