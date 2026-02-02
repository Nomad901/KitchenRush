using System;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    public virtual void interact(Player pPlayer)
    {}
    public virtual void interactAlternate(Player pPlayer)
    {}
    
    public Transform getKitchenObjTransform()
    {
        return mDefaultTopPoint;
    }
    public void setKitchenObjTransform(Transform pTransform)
    {
        mDefaultTopPoint = pTransform;
    }
    public void setKitchenObject(KitchenObject pKitchenObject)
    {
        mKitchenObject = pKitchenObject;

        if (pKitchenObject != null)
            mOnAnyObjectPut?.Invoke(this, EventArgs.Empty);
    }
    public KitchenObject getKitchenObject()
    {
        return mKitchenObject;
    }
    public void clearKitchenObject()
    {
        mKitchenObject = null;
    }
    public bool hasKitchenObject()
    {
        return mKitchenObject != null;
    }
    public static void resetStaticData()
    {
        mOnAnyObjectPut = null;
    }

    [SerializeField]
    private Transform mDefaultTopPoint;

    private KitchenObject mKitchenObject;

    public static event EventHandler mOnAnyObjectPut;
}
