using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal.Internal;

public class CollisionSystem : MonoBehaviour
{
    private void Start()
    {
        mTransform = transform;
    }
    public bool handleCollisionPlayer(ref Vector3 pMoveDir, float pMoveSpeed)
    {
        float moveDistance = pMoveSpeed * Time.deltaTime;
        float playerSize = 0.7f;
        float playerHeight = 2.0f;

        bool canMove = !Physics.CapsuleCast(mTransform.position, mTransform.position + Vector3.up * playerHeight, playerSize, pMoveDir, moveDistance);
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(pMoveDir.x, 0.0f, 0.0f).normalized;
            canMove = (moveDirX.x > -0.5f || moveDirX.x < 0.5f) && !Physics.CapsuleCast(mTransform.position,
                                                                    mTransform.position + Vector3.up * playerHeight,
                                                                    playerSize, moveDirX, moveDistance);
            if (canMove)
                pMoveDir = moveDirX;
            else
            {
                Vector3 moveDirZ = new Vector3(0.0f, 0.0f, pMoveDir.z).normalized;
                canMove = (moveDirZ.z > -0.5f || moveDirZ.z < 0.5f) && !Physics.CapsuleCast(mTransform.position,
                                                                        mTransform.position + Vector3.up * playerHeight,
                                                                        playerSize, moveDirZ, moveDistance);
                if (canMove)
                    pMoveDir = moveDirZ;
            }
        }

        return canMove;
    }

    private Transform mTransform;
}
