using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    public virtual void interact(Player pPlayer)
    {

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
    private Transform mDefaultTopPoint;

    private KitchenObject mKitchenObject;
}
