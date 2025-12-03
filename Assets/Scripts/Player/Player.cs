using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Mono.Cecil;
using NUnit.Framework.Interfaces;
using System;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("There is more than one instance of singleton!");
        Instance = this;

        mPlayerInteractions = GetComponent<PlayerInteractions>();
        mPlayerMovement = GetComponent<PlayerMovement>();
    }
    [System.Obsolete]
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 144;
    }

    private void Update()
    {
        mPlayerInteractions.handleInteractions();
        mPlayerMovement.handleMovement(mPlayerInteractions.getGameInput());
    }

    public PlayerInteractions getPlayerInteractions()
    {
        return mPlayerInteractions;
    }
    public PlayerMovement getPlayerMovement()
    {
        return mPlayerMovement;
    }

    public Transform getKitchenObjTransform()
    {
        return mKitchenHoldPoint;
    }
    public void setKitchenObject(KitchenObject pKitchenObject)
    {
        mKitchenObject = pKitchenObject;
    }
    public KitchenObject getKitchenObject()
    {
        return mKitchenObject;
    }
    public void clearKitchenObject()
    {
        mKitchenObject = null;
    }
    public bool hasKitchenObject()
    {
        return mKitchenObject != null;
    }

    public static Player Instance { get; private set; }

    [SerializeField]
    private Transform mKitchenHoldPoint;

    private KitchenObject mKitchenObject;

    private PlayerInteractions mPlayerInteractions;
    private PlayerMovement mPlayerMovement;
}