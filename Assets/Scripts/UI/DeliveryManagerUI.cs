using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    private void Awake()
    {
        mRecipeTemplate.gameObject.SetActive(false);
    }
    private void Start()
    {
        DeliveryManager.mInstance.mOnRecipeSpawned += DeliveryManager_mOnRecipeSpawned;
        DeliveryManager.mInstance.mOnRecipeCompleted += DeliveryManager_mOnRecipeCompleted;

        updateVisual();
    }
    private void DeliveryManager_mOnRecipeCompleted(object sender, System.EventArgs e)
    {
        updateVisual();
    }
    private void DeliveryManager_mOnRecipeSpawned(object sender, System.EventArgs e)
    {
        updateVisual();
    }

    private void updateVisual()
    {
        foreach (Transform child in mContainer)
        {
            if (child == mRecipeTemplate)
                continue;
            Destroy(child.gameObject);
        }

        List<RecipeSO> waitingListObjects = DeliveryManager.mInstance.getWaitingListRecipeSO();
        foreach (RecipeSO recipeSO in waitingListObjects)
        {
            Transform recipeSOTransform = Instantiate(mRecipeTemplate, mContainer);
            recipeSOTransform.gameObject.SetActive(true);
            recipeSOTransform.GetComponent<DeliveryManagerUI_Single>().setRecipeSOName(recipeSO);
        }
    }

    [SerializeField]
    private Transform mContainer;
    [SerializeField]
    private Transform mRecipeTemplate;
}
