using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCounter : BaseCounter
{
    private void Start()
    {
        for (UInt32 i = 0; i < MAX_AMOUNT_OF_PLATES; ++i)
        {
            mListOfPlates.Add(mPlateKitchenObjectSO);
        }
    }
    private void Update()
    {
        
    }
    public override void interact(Player pPlayer)
    { 
        
    }
    public override void interactAlternate(Player pPlayer)
    { 
    
    }


    [SerializeField]
    private KitchenScriptObject mPlateKitchenObjectSO;
    private List<KitchenScriptObject> mListOfPlates;

    private const UInt32 MAX_AMOUNT_OF_PLATES = 5;
    private const UInt32 TIME_OF_APPEARING = 2;
}
