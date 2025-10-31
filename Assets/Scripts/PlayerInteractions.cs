using System;
using UnityEngine;
using static Player;

public class PlayerInteractions : MonoBehaviour
{
    private void Start()
    {
        mGameInput.mOnInteract += MGameInput_mOnInteract;
    }
    private void MGameInput_mOnInteract(object sender, System.EventArgs e)
    {
        if (mBaseCounter != null)
            mBaseCounter.interact(Player.Instance);
    }

    public void handleInteractions()
    {
        Vector2 inputVec = mGameInput.getMovementVector(true);

        Vector3 moveDir = new Vector3(inputVec.x, 0.0f, inputVec.y);

        if (moveDir != Vector3.zero)
            mLastInteraction = moveDir;

        float distanceInteraction = 2.0f;
        bool hasInteraction = Physics.Raycast(transform.position, mLastInteraction, out RaycastHit outRaycastHitInfo, distanceInteraction, mLayerMasks);
        if (hasInteraction)
        {
            if (outRaycastHitInfo.transform.TryGetComponent(out BaseCounter outBaseCounter))
            {
                if (outBaseCounter != mBaseCounter)
                    setSelectedCounter(outBaseCounter); // todo
            }
            else
                setSelectedCounter(null);
        }
        else
            setSelectedCounter(null);
    }

    private void setSelectedCounter(BaseCounter pBaseCounter)
    {
        this.mBaseCounter = pBaseCounter;

        mOnSelectedCounter?.Invoke(this, new OnSelectedCounterEventArgs { mBaseCounter = pBaseCounter });
    }
    public GameInput getGameInput()
    {
        return mGameInput;
    }
    
    public event EventHandler<OnSelectedCounterEventArgs> mOnSelectedCounter;

    [SerializeField]
    private GameInput mGameInput;
    [SerializeField]
    private LayerMask mLayerMasks;

    private BaseCounter mBaseCounter;
    private Vector3 mLastInteraction;
}
