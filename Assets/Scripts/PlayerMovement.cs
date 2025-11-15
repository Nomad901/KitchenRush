using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private void Start()
    {
        mMoveSpeed = 5.0f;
        mIsWalking = false;
        mCollisionSystem = GetComponent<CollisionSystem>();

        mTransform = transform;
    }

    public void handleMovement(GameInput gameInput)
    {
        Vector2 inputVec = gameInput.getMovementVector(true);

        Vector3 moveDir = new Vector3(inputVec.x, 0.0f, inputVec.y);

        bool canMove = mCollisionSystem.handleCollisionPlayer(ref moveDir, mMoveSpeed);
        if (canMove)
            mTransform.position += moveDir * mMoveSpeed * Time.deltaTime;

        handleRotation(inputVec, moveDir);
    }
    private void handleRotation(Vector2 pInputVec, Vector3 pMoveDir)
    {
        mIsWalking = pInputVec != Vector2.zero;

        if (!mIsWalking || pMoveDir.sqrMagnitude < 0.001f)
            return;

        float rotateSpeed = 10.0f;

        Quaternion targetRotation = Quaternion.LookRotation(pMoveDir);
        mTransform.rotation = Quaternion.Lerp(mTransform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
    }

    public bool isWalking()
    {
        return mIsWalking;
    }

    [SerializeField]
    private float mMoveSpeed;

    private CollisionSystem mCollisionSystem;
    private Transform mTransform;
    private bool mIsWalking;
}
