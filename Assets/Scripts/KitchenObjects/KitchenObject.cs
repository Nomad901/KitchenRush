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
    public void setKitchenScriptObject(KitchenScriptObject pKitchenScriptObject)
    {
        mKitchenScriptObject = pKitchenScriptObject;
    }
    public void destroySelf()
    {
        mIKitchenObjectParent.clearKitchenObject();
        Destroy(gameObject);
    }

    public bool tryGetPlate(out PlateKitchenObject pPlateKitchenObject)
    {
        if(this is PlateKitchenObject)
        {
            pPlateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        pPlateKitchenObject = null;
        return false;
    }

    public static KitchenObject spawnKitchenObject(KitchenScriptObject pKitchenScriptObject, 
                                                   IKitchenObjectParent pIKitchenObjectParent)
    {
        Transform kitchenObjectTransform = Instantiate(pKitchenScriptObject.mPrefab);
        KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
        kitchenObject.setKitchenObjectParent(pIKitchenObjectParent);
        kitchenObject.setKitchenScriptObject(pKitchenScriptObject);
        return kitchenObject;
    }

    [SerializeField]
    private KitchenScriptObject mKitchenScriptObject;
    private IKitchenObjectParent mIKitchenObjectParent;
}
