using UnityEngine;

public class CollisionSystem : MonoBehaviour
{
    public bool handleCollisionPlayer(ref Vector3 pMoveDir, float pMoveSpeed)
    {
        float moveDistance = pMoveSpeed * Time.deltaTime;
        float playerSize = 0.7f;
        float playerHeight = 2.0f;

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, pMoveDir, moveDistance);
        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(pMoveDir.x, 0.0f, 0.0f).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDirX, moveDistance);
            if (canMove)
                pMoveDir = moveDirX;
            else
            {
                Vector3 moveDirZ = new Vector3(0.0f, 0.0f, pMoveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerSize, moveDirZ, moveDistance);
                if (canMove)
                    pMoveDir = moveDirZ;
            }
        }

        return canMove;
    }
}
