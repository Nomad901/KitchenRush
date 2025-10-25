using UnityEditor;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    public void setKitchenObject(IKitchenObjectParent pIKitchenObjectParent)
    {
        if (mIKitchenObjectParent != null)
            mIKitchenObjectParent.clearKitchenObject();

        mIKitchenObjectParent = pIKitchenObjectParent;

        if (pIKitchenObjectParent.hasKitchenObject())
            Debug.LogError("The clear counter has an object!");
        pIKitchenObjectParent.setKitchenObject(this);
                
        transform.parent = mIKitchenObjectParent.getKitchenObjTransform();
        transform.localPosition = Vector3.zero;
        //float rangeOfSpawning = 0.3f;
        //float offsetX = Random.Range(-rangeOfSpawning, rangeOfSpawning);
        //float offsetZ = Random.Range(-rangeOfSpawning, rangeOfSpawning);
        //
        //Vector3 randomOffset = new Vector3(offsetX,
        //                                   0.0f,
        //                                   offsetZ);
        //transform.localPosition = randomOffset;
        //
        //float rotationLevel = Random.Range(0.0f, 360.0f);
        //transform.GetChild(0).Rotate(0.0f, rotationLevel, 0.0f);
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
