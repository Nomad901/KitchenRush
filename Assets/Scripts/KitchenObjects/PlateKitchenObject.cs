using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    private void Awake()
    {
        mListKitchenObjects = new List<KitchenScriptObject>();
    }

    public bool tryAddIngredient(KitchenScriptObject pKitchenScriptObject)
    {
        if (!mListAllowedKitchenObject.Contains(pKitchenScriptObject))
            return false;
        if (mListKitchenObjects.Contains(pKitchenScriptObject))
            return false;
        mListKitchenObjects.Add(pKitchenScriptObject);
        return true;
    }

    private List<KitchenScriptObject> mListKitchenObjects;

    [SerializeField]
    private List<KitchenScriptObject> mListAllowedKitchenObject;
}
