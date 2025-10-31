using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private void Start()
    {
        mMoveSpeed = 5.0f;
        mIsWalking = false;
    }

    public void handleMovement(GameInput gameInput)
    {
        Vector2 inputVec = gameInput.getMovementVector(true);

        Vector3 moveDir = new Vector3(inputVec.x, 0.0f, inputVec.y);

        CollisionSystem collisions = new CollisionSystem();
        bool canMove = collisions.handleCollisionPlayer(ref moveDir, mMoveSpeed);
        Debug.Log(canMove);
        if (canMove)
        {
            transform.position += moveDir * mMoveSpeed * Time.deltaTime;
        }

        handleRotation(inputVec, moveDir);
    }
    private void handleRotation(Vector2 pInputVec, Vector3 pMoveDir)
    {
        mIsWalking = pInputVec != Vector2.zero;
        if (mIsWalking)
        {
            float rotateSpeed = 10.0f;
            transform.forward = Vector3.Slerp(transform.forward, pMoveDir, Time.deltaTime * rotateSpeed);
        }
    }

    public bool isWalking()
    {
        return mIsWalking;
    }

    [SerializeField]
    private float mMoveSpeed;

    private bool mIsWalking;
}
