using UnityEditor;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    public void setKitchenObjectParent(IKitchenObjectParent pIKitchenObjectParent)
    {
        if (mIKitchenObjectParent != null)
            mIKitchenObjectParent.clearKitchenObject();

        mIKitchenObjectParent = pIKitchenObjectParent;

        if (pIKitchenObjectParent.hasKitchenObject())
            Debug.LogError("The clear counter has an object!");
        pIKitchenObjectParent.setKitchenObject(this);
                
        transform.parent = mIKitchenObjectParent.getKitchenObjTransform();
        transform.localPosition = Vector3.zero;
    }
    public KitchenScriptObject getKitchenScriptObject()
    {
        return mKitchenScriptObject;
    }
    public IKitchenObjectParent getIKitchenObjectParent()
    {
        return mIKitchenObjectParent;
    }

    [SerializeField]
    private KitchenScriptObject mKitchenScriptObject;
    private IKitchenObjectParent mIKitchenObjectParent;
}
