using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ClearCounter : MonoBehaviour
{
    private void Update()
    {
        if(mTesting && Input.GetKeyDown(KeyCode.T))
        {
            if(mKitchenObject != null)
                mKitchenObject.setClearCounter(mSecondClearCounter);
        }
    }
    public void interact()
    {
        if (mKitchenObject == null)
        {
            Transform kitchenObjectTransform = Instantiate(mKitchenScriptObject.mPrefab, mDefaultTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().setClearCounter(this);

            //float rangeOfSpawning = 0.3f;
            //float offsetX = Random.Range(-rangeOfSpawning, rangeOfSpawning);
            //float offsetZ = Random.Range(-rangeOfSpawning, rangeOfSpawning);

            //Vector3 randomOffset = new Vector3(offsetX,
            //                                   0.0f,
            //                                   offsetZ);
            //kitchenObjectTransform.localPosition = randomOffset;

            //float rotationLevel = Random.Range(0.0f, 360.0f);
            //kitchenObjectTransform.GetChild(0).Rotate(0.0f, rotationLevel, 0.0f);
            //mKitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            //mKitchenObject.setClearCounter(this);
        }
        else
        {
            Debug.Log(mKitchenObject.getClearCounter());
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
    [SerializeField]
    private ClearCounter mSecondClearCounter;
    [SerializeField]
    private bool mTesting;

    private KitchenObject mKitchenObject;
}
