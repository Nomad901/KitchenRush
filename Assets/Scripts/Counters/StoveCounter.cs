using System;
using UnityEditor;
using UnityEngine;
using static CutCounter;

public class StoveCounter : BaseCounter, IHasProgress
{
    private void Start()
    {
        mFryingTimer = 0.0f;
        mBurningTimer = 0.0f;
        mFryingState = fryingState.IDLE;
    }
    private void Update()
    {
        switch (mFryingState)
        {
            case fryingState.IDLE:
                mOnBarChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    mProgressFloat = 0.0f
                });
                break;
            case fryingState.FRYING:
                mFryingTimer += Time.deltaTime;

                mOnBarChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    mProgressFloat = (mFryingTimer / mFryingRecipeSO.mFryingTimerMax)
                });

                if (mFryingTimer >= mFryingRecipeSO.mFryingTimerMax)
                {
                    mFryingTimer = 0.0f;
                    
                    getKitchenObject().destroySelf();
                    KitchenObject.spawnKitchenObject(mFryingRecipeSO.mOutput, this);

                    mFryingState = fryingState.FRIED;
                    mOnStateChange?.Invoke(this, new OnStateChangeArgs
                    {
                        mState = fryingState.FRIED
                    });
                }
                break;
            case fryingState.FRIED:
                mBurningTimer += Time.deltaTime;

                mOnBarChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    mProgressFloat = (mBurningTimer / mBurningRecipeSO.mBurningTimerMax)
                });

                if (mBurningTimer >= mBurningRecipeSO.mBurningTimerMax)
                {
                    mFryingState = fryingState.BURNED;
                    mOnStateChange?.Invoke(this, new OnStateChangeArgs
                    {
                        mState = fryingState.BURNED
                    });
                }
                break;
            case fryingState.BURNED:
                mBurningTimer = 0.0f;

                mOnBarChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    mProgressFloat = 0.0f
                });

                getKitchenObject().destroySelf();
                KitchenObject.spawnKitchenObject(mBurningRecipeSO.mOutput, this);
                mFryingState = fryingState.IDLE;
                break;
        }
    }

    public override void interact(Player pPlayer)
    {
        if (!hasKitchenObject())
        {
            if (pPlayer.hasKitchenObject())
            {
                if(hasRecipeWithInput(pPlayer.getKitchenObject().getKitchenScriptObject()))
                {
                    pPlayer.getKitchenObject().setKitchenObjectParent(this);

                    mFryingRecipeSO = getFryingRecipeSOWithInput(getKitchenObject().getKitchenScriptObject());
                    mBurningRecipeSO = getBurningRecipeSOWithInput(mFryingRecipeSO.mOutput);

                    mFryingState = fryingState.FRYING;
                    mOnStateChange?.Invoke(this, new OnStateChangeArgs
                    {
                        mState = fryingState.FRYING
                    });
                    mFryingTimer = 0.0f;
                    mBurningTimer = 0.0f;
                }
            }
        }
        else
        {
            if (!pPlayer.hasKitchenObject())
            {
                getKitchenObject().setKitchenObjectParent(pPlayer);
                mFryingState = fryingState.IDLE;
                mOnStateChange?.Invoke(this, new OnStateChangeArgs
                {
                    mState = fryingState.IDLE
                });
            }
            else
            {
                if (pPlayer.getKitchenObject().tryGetPlate(out PlateKitchenObject plate))
                {
                    if (plate.tryAddIngredient(getKitchenObject().getKitchenScriptObject()))
                        getKitchenObject().destroySelf();
                    mFryingState = fryingState.IDLE;
                    mOnStateChange?.Invoke(this, new OnStateChangeArgs
                    {
                        mState = fryingState.IDLE
                    });
                    mOnBarChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        mProgressFloat = 0.0f
                    });
                }
            }
        }
    }

    private bool hasRecipeWithInput(KitchenScriptObject pInputKitchenScriptObject)
    {
        FryingRecipeSO fryingRecipeSO = getFryingRecipeSOWithInput(pInputKitchenScriptObject);
        return fryingRecipeSO != null;
    }
    private FryingRecipeSO getFryingRecipeSOWithInput(KitchenScriptObject pInputScriptObject)
    {
        foreach (FryingRecipeSO fryingRecipeElement in mFryingRecipeSOArray)
        {
            if (fryingRecipeElement.mInput == pInputScriptObject)
                return fryingRecipeElement;
        }
        return null;
    }
    private BurningRecipeSO getBurningRecipeSOWithInput(KitchenScriptObject pInputScriptObject)
    {
        foreach (BurningRecipeSO burningRecipeElement in mBurningRecipeSOArray)
        {
            if (burningRecipeElement.mInput == pInputScriptObject)
                return burningRecipeElement;
        }
        return null;
    }
    public bool isFried()
    {
        return mFryingState == fryingState.FRIED;
    }
    public bool isIdle()
    {
        return mFryingState == fryingState.IDLE;
    }

    [SerializeField]
    private FryingRecipeSO[] mFryingRecipeSOArray;
    [SerializeField]
    private BurningRecipeSO[] mBurningRecipeSOArray;

    private float mFryingTimer;
    private float mBurningTimer;

    private FryingRecipeSO mFryingRecipeSO;
    private BurningRecipeSO mBurningRecipeSO;

    public enum fryingState
    {
        IDLE = 0,
        FRYING = 1,
        FRIED = 2,
        BURNED = 3
    }
    private fryingState mFryingState;

    public event EventHandler<OnStateChangeArgs> mOnStateChange;
    public class OnStateChangeArgs : EventArgs
    {
        public fryingState mState;
    }

    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> mOnBarChanged;
}
