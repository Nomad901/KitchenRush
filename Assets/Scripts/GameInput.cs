using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    private void Awake()
    {
        mPlayerInputActions = new PlayerInputActions();
        mPlayerInputActions.Player.Enable();

        mPlayerInputActions.Player.Interact.performed += Interact_performed;
        mPlayerInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
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
    public PlayerInputActions getPlayerInputActions()
    {
        return mPlayerInputActions;
    }
    private PlayerInputActions mPlayerInputActions;

    public event EventHandler mOnInteract;
    public event EventHandler mOnInteractAlternate;
}
