using UnityEngine;
using UnityEngine.UI;

public class PlateSingleIconUI : MonoBehaviour
{
    public void setKitchenObjectSO(KitchenScriptObject pKitchenScriptObject)
    {
        mImage.sprite = pKitchenScriptObject.mSprite;
    }
    
    [SerializeField]
    private Image mImage;
}
