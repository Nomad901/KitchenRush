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

    private PlayerInputActions mPlayerInputActions;

    public event EventHandler mOnInteract;
}
