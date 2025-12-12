using UnityEngine;

public class PlateIconUI : MonoBehaviour
{
    private void Awake()
    {
        mIconTemplate.gameObject.SetActive(false);
    }
    private void Start()
    {
        mPlateKitchenObject.mOnKitchenObjectAdded += MPlateKitchenObject_mOnKitchenObjectAdded;
    }

    private void MPlateKitchenObject_mOnKitchenObjectAdded(object sender, PlateKitchenObject.KitchenObjectAddedEventArgs e)
    {
        updateVisuals();    
    }
    private void updateVisuals()
    {
        clearAllChildren();

        Transform parentTransform = transform; 

        foreach (KitchenScriptObject kitchenObjSO in mPlateKitchenObject.getListKitchenObjectSO())
        {
            Transform spriteTransform = Instantiate(mIconTemplate, parentTransform);
            spriteTransform.gameObject.SetActive(true);
            spriteTransform.GetComponent<PlateSingleIconUI>().setKitchenObjectSO(kitchenObjSO);
        }
    }
    private void clearAllChildren()
    {
        foreach (Transform transformChild in transform)
        {
            if (transformChild == mIconTemplate)
                continue;
            Destroy(transformChild.gameObject);
        }
    }

    [SerializeField]
    private PlateKitchenObject mPlateKitchenObject;
    [SerializeField]
    private Transform mIconTemplate;
}
