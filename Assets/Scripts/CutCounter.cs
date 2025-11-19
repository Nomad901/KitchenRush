using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class CutCounter : BaseCounter
{
    private void Start()
    {
        mKitchenObjectNames = new string[(Int32)KitchenObjectType.NUM_OF_OBJECTS] { "Tomato", "Cheese", "Cabbage", "Error" };
    }
    public override void interact(Player pPlayer)
    {
        if (!hasKitchenObject())
        {
            if (pPlayer.hasKitchenObject())
                pPlayer.getKitchenObject().setKitchenObjectParent(this);
        }
        else
        {
            if (!pPlayer.hasKitchenObject())
                getKitchenObject().setKitchenObjectParent(pPlayer);
        }
    }

    public override void interactAlternate(Player pPlayer)
    {
        if(hasKitchenObject())
        {
            string kitchenObjectName = manageString(getKitchenObject()?.name);
            manageKitchenObjectType(kitchenObjectName);
            if (mKitchenObjectType == KitchenObjectType.ERROR)
                return;

            getKitchenObject().destroySelf();

            UInt32 indexKitchenScriptObjects = 0;
            switch (mKitchenObjectType)
            {
                case KitchenObjectType.TOMATO:
                    indexKitchenScriptObjects = 0;
                    break;
                case KitchenObjectType.CHEESE:
                    indexKitchenScriptObjects = 1;
                    break;
                case KitchenObjectType.CABBAGE:
                    indexKitchenScriptObjects = 2;
                    break;
                default:
                    break;
            }

            KitchenObject.spawnKitchenObject(mKitchenScriptObject[indexKitchenScriptObjects], this);
        }
    }

    //
    // manages string through clearing redundant braces;
    // for example: Tomato(clone) -> Tomato;
    //
    private string manageString(string pString)
    {
        if(pString.Contains('(') && pString.Contains(')'))
        {
            Int32 indexOfFirstBrace = pString.IndexOf('(');
            pString = pString.Remove(indexOfFirstBrace);
        }
        return pString;
    }
    private void manageKitchenObjectType(string pKitchenObjectName)
    {
        if (pKitchenObjectName == mKitchenObjectNames[(Int32)KitchenObjectType.TOMATO])
            mKitchenObjectType = KitchenObjectType.TOMATO;
        else if (pKitchenObjectName == mKitchenObjectNames[(Int32)KitchenObjectType.CHEESE])
            mKitchenObjectType = KitchenObjectType.CHEESE;
        else if (pKitchenObjectName == mKitchenObjectNames[(Int32)KitchenObjectType.CABBAGE])
            mKitchenObjectType = KitchenObjectType.CABBAGE;
        else
            mKitchenObjectType = KitchenObjectType.ERROR;
    }

    [SerializeField]
    private KitchenScriptObject[] mKitchenScriptObject;

    private enum KitchenObjectType
    {
        TOMATO         = 0,
        CHEESE         = 1,
        CABBAGE        = 2,
        ERROR          = 3,
        NUM_OF_OBJECTS = 4
    };
    private string[] mKitchenObjectNames;
    private KitchenObjectType mKitchenObjectType;
}
