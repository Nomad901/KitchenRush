using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Mono.Cecil;

public class Player : MonoBehaviour
{
    [System.Obsolete]
    private void Start()
    {
        mKeyboard = Keyboard.current;
        mCharPos = Vector3.zero;
        mIsWalking = false;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;

        Physics.autoSimulation = true;
        Physics.autoSyncTransforms = false;
    }
    private void Update()
    {
        mCharPos = Vector3.zero;

        if (mKeyboard != null)
        {
            if (mKeyboard.wKey.isPressed)
                mCharPos.z = 1.0f;
            if (mKeyboard.sKey.isPressed)
                mCharPos.z = -1.0f;
            if (mKeyboard.aKey.isPressed)
                mCharPos.x = -1.0f;
            if (mKeyboard.dKey.isPressed)
                mCharPos.x = 1.0f;
        }
    
        if (mCharPos != Vector3.zero)
        {
            mIsWalking = true;
            mCharPos.Normalize();
            float factorRotation = 10.0f;
            transform.forward = Vector3.Slerp(transform.forward, mCharPos, Time.deltaTime * factorRotation);
            transform.position += mCharPos * mMoveSpeed * Time.deltaTime;
        }
        else
            mIsWalking = false;
    }
    public bool isWalking()
    {
        return mIsWalking;
    }

    // variables
    // ---------
    [SerializeField]
    private float mMoveSpeed = 1.0f;

    private bool mIsWalking;

    private Vector3 mCharPos;
    private Keyboard mKeyboard;
    // ---------
}