using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Mono.Cecil;
using NUnit.Framework.Interfaces;
using System;

public class Player : MonoBehaviour
{
    // private
    // -------
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There is more than one instance of singleton!");
        Instance = this;
    }
    [System.Obsolete]
    private void Start()
    {
        mIsWalking = false;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;

        Physics.autoSimulation = true;
        Physics.autoSyncTransforms = false;

        mGameInput.mOnInteract += MGameInput_mOnInteract;
    }

    private void MGameInput_mOnInteract(object sender, System.EventArgs e)
    {
        if (mSelectedClearCounter != null)
            mSelectedClearCounter.interact();
    }

    private void Update()
    {
        handleMovement();
        handleInteractions();
    }

    // Interactions
    private void handleInteractions()
    {
        Vector2 inputVec = mGameInput.getMovementVector(true);

        Vector3 moveDir = new Vector3(inputVec.x, 0.0f, inputVec.y);

        if (moveDir != Vector3.zero)
            mLastInteraction = moveDir;

        float distanceInteraction = 2.0f;
        bool hasInteraction = Physics.Raycast(transform.position, mLastInteraction, out RaycastHit outRaycastHitInfo, distanceInteraction, mLayerMasks);
        if (hasInteraction)
        {
            if (outRaycastHitInfo.transform.TryGetComponent(out ClearCounter outClearCounter))
            {
                if (outClearCounter != mSelectedClearCounter)
                    setSelectedCounter(outClearCounter);
            }
            else
                setSelectedCounter(null);
        }
        else
            setSelectedCounter(null);
    }

    // Movement
    private void handleMovement()
    {
        Vector2 inputVec = mGameInput.getMovementVector(true);

        Vector3 moveDir = new Vector3(inputVec.x, 0.0f, inputVec.y);

        bool canMove = handleCollision(ref moveDir);
        if (canMove)
            transform.position += moveDir * mMoveSpeed * Time.deltaTime;

        handleRotation(inputVec, moveDir);
    }
    private void handleRotation(Vector2 pInputVec, Vector3 pMoveDir)
    {
        mIsWalking = pInputVec != Vector2.zero;
        if (mIsWalking)
        {
            float rotateSpeed = 10.0f;
            Quaternion targetRotation = Quaternion.LookRotation(pMoveDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
        }
    }
    private bool handleCollision(ref Vector3 pMoveDir)
    {
        float moveDistance = mMoveSpeed * Time.deltaTime;
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
    private void setSelectedCounter(ClearCounter pSelectedCounter)
    {
        mSelectedClearCounter = pSelectedCounter;

        mOnSelectedCounter?.Invoke(this, new OnSelectedCounterEventArgs { mSelectedCounter = pSelectedCounter });
    }
    // -------

    // public
    // ------
    public bool isWalking()
    {
        return mIsWalking;
    }
    public class OnSelectedCounterEventArgs : EventArgs
    {
        public ClearCounter mSelectedCounter;
    }
    // ------

    // variables
    // ---------
    // public
    public event EventHandler<OnSelectedCounterEventArgs> mOnSelectedCounter;
    public static Player Instance { get; private set; }
    // private
    [SerializeField]
    private float mMoveSpeed = 5.0f;
    [SerializeField]
    private GameInput mGameInput;
    [SerializeField]
    private LayerMask mLayerMasks;

    private ClearCounter mSelectedClearCounter;
    private Vector3 mLastInteraction;
    private bool mIsWalking;
    // ---------
}