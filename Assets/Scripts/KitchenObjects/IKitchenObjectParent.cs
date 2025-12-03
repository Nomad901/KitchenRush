using UnityEngine;

public interface IKitchenObjectParent
{
    public Transform getKitchenObjTransform();
    public void setKitchenObject(KitchenObject pKitchenObject);
    public KitchenObject getKitchenObject();
    public void clearKitchenObject();
    public bool hasKitchenObject();
}
