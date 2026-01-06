using Mono.Cecil.Cil;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using TreeEditor;
using Unity.Mathematics;
using UnityEditorInternal;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    private void Awake()
    {
        mInstance = this;
        mSuccessfulRecipeQuantity = 0;
        mWaitingRecipeSOList = new List<RecipeSO>();
    }
    private void Update()
    {
        mTimerOfOrder -= Time.deltaTime;
        if (mTimerOfOrder <= 0.0f &&
            mWaitingRecipeSOList.Count < WAITING_RECIPES_MAX)
        {
            mTimerOfOrder = TIMER_OF_ORDER_MAX;

            Int32 randomIndex = UnityEngine.Random.Range(0, mRecipeSOList.mListRecipeSO.Count);
            RecipeSO waitingRecipeSO = mRecipeSOList.mListRecipeSO[randomIndex];
            mWaitingRecipeSOList.Add(waitingRecipeSO);
            mOnRecipeSpawned?.Invoke(this, EventArgs.Empty);
        }
    }
    public void deliverPlate(PlateKitchenObject pPlateKitchenObject)
    {
        for (int i = 0; i < mWaitingRecipeSOList.Count; ++i)
        {
            RecipeSO waitingRecipeSO = mWaitingRecipeSOList[i];

            if(waitingRecipeSO.mNeededKitchenObjects.Count == pPlateKitchenObject.getListKitchenObjectSO().Count)
            {
                bool plateContentMatchesRecipe = true;
                foreach (KitchenScriptObject kitchenObjectSO in waitingRecipeSO.mNeededKitchenObjects)
                {
                    if (!pPlateKitchenObject.getListKitchenObjectSO().Contains(kitchenObjectSO))
                    {
                        plateContentMatchesRecipe = false;
                        break;
                    }
                }
                if (plateContentMatchesRecipe) 
                {
                    mSuccessfulRecipeQuantity++;
                    mWaitingRecipeSOList.RemoveAt(i);
                    mOnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    mOnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        mOnRecipeFailed?.Invoke(this, EventArgs.Empty);
    }
    public List<RecipeSO> getWaitingListRecipeSO()
    {
        return mWaitingRecipeSOList;
    }
    public Int32 getSuccessfulRecipeQuantity()
    {
        return mSuccessfulRecipeQuantity;
    }

    public static DeliveryManager mInstance { get; private set; }

    [SerializeField]
    private RecipeListSO mRecipeSOList;

    private List<RecipeSO> mWaitingRecipeSOList;
    private float mTimerOfOrder;
    
    private const float TIMER_OF_ORDER_MAX = 4.0f;
    private const Int32 WAITING_RECIPES_MAX = 4;
    
    public event EventHandler mOnRecipeSpawned;
    public event EventHandler mOnRecipeCompleted;
    public event EventHandler mOnRecipeSuccess;
    public event EventHandler mOnRecipeFailed;

    private Int32 mSuccessfulRecipeQuantity;
}
