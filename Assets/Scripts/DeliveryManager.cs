using Mono.Cecil.Cil;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using TreeEditor;
using Unity.Mathematics;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    private void Awake()
    {
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
            Debug.Log(waitingRecipeSO.name);
            mWaitingRecipeSOList.Add(waitingRecipeSO);
        }
    }

    [SerializeField]
    private RecipeListSO mRecipeSOList;

    private List<RecipeSO> mWaitingRecipeSOList;
    private float mTimerOfOrder;
    
    private const float TIMER_OF_ORDER_MAX = 4.0f;
    private const Int32 WAITING_RECIPES_MAX = 4;
}
