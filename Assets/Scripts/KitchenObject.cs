using UnityEditor;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    public KitchenScriptObject getKitchenScriptObject()
    {
        return mKitchenScriptObject;
    }
    public ClearCounter getClearCounter()
    {
        return mClearCounter;
    }
    public void setClearCounter(ClearCounter pClearCounter)
    {
        if (mClearCounter != null)
            mClearCounter.clearKitchenObject();

        mClearCounter = pClearCounter;

        //if (pClearCounter.hasKitchenObject())
        //    Debug.LogError("Clear counter has a kitchen object!");
        pClearCounter.setKitchenObject(this);
                
        transform.parent = mClearCounter.getKitchenObjTransform();
        transform.localPosition = Vector3.zero;
    }
    

    [SerializeField]
    private KitchenScriptObject mKitchenScriptObject;
    private ClearCounter mClearCounter;
}
