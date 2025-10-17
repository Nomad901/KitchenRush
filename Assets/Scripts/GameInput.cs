using UnityEngine;

public class GameInput : MonoBehaviour
{
    private void Awake()
    {
        mPlayerInputActions = new PlayerInputActions();
        mPlayerInputActions.Player.Enable();
    }
    public Vector2 getMovementVector(bool pGetNormalized)
    {
        Vector2 inputVector = mPlayerInputActions.Player.Move.ReadValue<Vector2>();

        if(pGetNormalized)
            inputVector = inputVector.normalized;

        return inputVector;
    }

    private PlayerInputActions mPlayerInputActions;
}
