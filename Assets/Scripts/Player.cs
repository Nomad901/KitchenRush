using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Mono.Cecil;
using NUnit.Framework.Interfaces;

public class Player : MonoBehaviour
{
    [System.Obsolete]
    private void Start()
    {
        mIsWalking = false;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;

        Physics.autoSimulation = true;
        Physics.autoSyncTransforms = false;
    }
    private void Update()
    {
        Vector2 inputVec = mGameInput.getMovementVector(true);

        Vector3 moveDir = new Vector3(inputVec.x, 0.0f, inputVec.y);

        float moveDistance = mMoveSpeed * Time.deltaTime;
        float playerSize = 0.7f;
        float playerHeight = 2.0f;

        bool canMove = !Physics.CapsuleCast(transform.forward, transform.position + Vector3.up * playerHeight, playerSize, moveDir, moveDistance);
        if(canMove)
            transform.position += moveDir * moveDistance;

        mIsWalking = inputVec != Vector2.zero;
        if (mIsWalking)
        {
            float rotateSpeed = 5.0f;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }
    }
    public bool isWalking()
    {
        return mIsWalking;
    }

    // variables
    // ---------
    [SerializeField]
    private float mMoveSpeed = 5.0f;
    [SerializeField]
    private GameInput mGameInput;

    private bool mIsWalking;
    // ---------
}