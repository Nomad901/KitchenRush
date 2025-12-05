using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateIngredientsCompleteVisual : MonoBehaviour
{
    private void Start()
    {
        mPlateKitchenObject.mOnKitchenObjectAdded += MPlateKitchenObject_mOnKitchenObjectAdded;

        foreach (var item in mKitchenScriptObject_GameObjectList)
        {
            item.mGameObject.SetActive(false);
        }
    }

    private void MPlateKitchenObject_mOnKitchenObjectAdded(object sender, PlateKitchenObject.KitchenObjectAddedEventArgs e)
    {
        foreach (var item in mKitchenScriptObject_GameObjectList)
        {
            if (item.mKitchenScriptObject == e.mKitchenScriptObject)
                item.mGameObject.SetActive(true);
        }
    }

    [SerializeField]
    private PlateKitchenObject mPlateKitchenObject;
    [SerializeField]
    private List<KitchenScriptObject_GameObject> mKitchenScriptObject_GameObjectList;

    [Serializable]
    public struct KitchenScriptObject_GameObject
    {
        public KitchenScriptObject mKitchenScriptObject;
        public GameObject mGameObject;
    }
}
