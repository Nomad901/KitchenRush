using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{
    public override void interact(Player pPlayer)
    {
        if (mKitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(mKitchenScriptObject.mPrefab, mDefaultTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().setKitchenObject(this);
        }
        else
        {
            mKitchenObject.setKitchenObject(pPlayer);
        }
    }
    public Transform getKitchenObjTransform()
    {
        return mDefaultTopPoint;
    }
    public void setKitchenObject(KitchenObject pKitchenObject)
    {
        mKitchenObject = pKitchenObject;
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

    [SerializeField]
    private KitchenScriptObject mKitchenScriptObject;
    [SerializeField]
    private Transform mDefaultTopPoint;

    private KitchenObject mKitchenObject;
}
