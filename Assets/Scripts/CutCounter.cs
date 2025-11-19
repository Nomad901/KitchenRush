using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class CutCounter : BaseCounter
{
    private void Start()
    {
        mKitchenObjectNames = new string[(Int32)KitchenObjectType.NUM_OF_OBJECTS] { "Tomato", "Cheese", "Cabbage", "Error" };
        mNumberOfSlices = new Int32[(Int32)KitchenObjectType.NUM_OF_OBJECTS]      {        3,         3,        5,       0 };
    }
    public override void interact(Player pPlayer)
    {
        if (!hasKitchenObject())
        {
            if (pPlayer.hasKitchenObject())
            {
                mCurrentSliceNumber = 0;
                
                string kitchenObjectName = manageString(pPlayer.getKitchenObject()?.name);
                manageKitchenObjectType(kitchenObjectName);
                if(mKitchenObjectType != KitchenObjectType.ERROR)
                {
                    mOnBarChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        mProgressFloat = (float)mCurrentSliceNumber / mNumberOfSlices[(Int32)mKitchenObjectType]
                    });
                }

                pPlayer.getKitchenObject().setKitchenObjectParent(this);
            }
        }
        else
        {
            if (!pPlayer.hasKitchenObject())
            {
                getKitchenObject().setKitchenObjectParent(pPlayer);
                mOnBarChanged?.Invoke(this, new OnProgressChangedEventArgs
                {
                    mProgressFloat = 0.0f
                });
            }
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
            else
            {
                mCurrentSliceNumber++;

                mOnCut?.Invoke(this, EventArgs.Empty);

                mOnBarChanged?.Invoke(this, new OnProgressChangedEventArgs
                {
                    mProgressFloat = (float)mCurrentSliceNumber / mNumberOfSlices[(Int32)mKitchenObjectType]
                });
            }

            if (mCurrentSliceNumber == mNumberOfSlices[(Int32)mKitchenObjectType])
            {
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
    private Int32[] mNumberOfSlices;
    private Int32 mCurrentSliceNumber;

    private KitchenObjectType mKitchenObjectType;

    public event EventHandler<OnProgressChangedEventArgs> mOnBarChanged;
    public class OnProgressChangedEventArgs : EventArgs
    {
        public float mProgressFloat;
    }

    public event EventHandler mOnCut;
}
