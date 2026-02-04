using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlateCounter : BaseCounter
{
    private void Update()
    {
        mCurrentTime += Time.deltaTime;
        if (GameHandler.mInstance.gameIsPlaying() &&
            mCurrentTime >= TIME_OF_APPEARING     &&
            mCurrentAmountOfPlates < MAX_AMOUNT_OF_PLATES)
        {
            mCurrentTime = 0.0f;
            if (mCurrentAmountOfPlates < MAX_AMOUNT_OF_PLATES)
            {
                mCurrentAmountOfPlates++;
                mOnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public override void interact(Player pPlayer)
    { 
        if (!pPlayer.hasKitchenObject())
        {
            if (mCurrentAmountOfPlates > 0)
            {
                mCurrentAmountOfPlates--;

                KitchenObject.spawnKitchenObject(mPlateKitchenObjectSO, pPlayer);

                mOnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    [SerializeField]
    private KitchenScriptObject mPlateKitchenObjectSO;
    
    private const UInt32 MAX_AMOUNT_OF_PLATES = 5;
    private const UInt32 TIME_OF_APPEARING = 2;
    private float mCurrentTime = 0.0f;
    private UInt32 mCurrentAmountOfPlates = 0;

    public EventHandler mOnPlateSpawned;
    public EventHandler mOnPlateRemoved;
}
