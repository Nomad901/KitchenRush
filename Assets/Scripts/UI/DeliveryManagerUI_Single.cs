using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerUI_Single : MonoBehaviour
{
    private void Awake()
    {
        mIconTemplate.gameObject.SetActive(false);
    }
    public void setRecipeSOName(RecipeSO pRecipeSO)
    {
        mRecipeNameText.text = pRecipeSO.mRecipeName;

        foreach (Transform child in mIconContainer)
        {
            if (child == mIconTemplate)
                continue;
            Destroy(child.gameObject);
        }

        foreach (KitchenScriptObject kitchenObjSO in pRecipeSO.mNeededKitchenObjects)
        {
            Transform iconTransform = Instantiate(mIconTemplate, mIconContainer);
            iconTransform.gameObject.SetActive(true);
            iconTransform.GetComponent<Image>().sprite = kitchenObjSO.mSprite;
        }

    }

    [SerializeField]
    private TextMeshProUGUI mRecipeNameText;
    [SerializeField]
    private Transform mIconContainer;
    [SerializeField]
    private Transform mIconTemplate;
}
