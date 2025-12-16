using TMPro;
using UnityEngine;

public class DeliveryManagerUI_Single : MonoBehaviour
{
    public void setRecipeSOName(RecipeSO pRecipeSO)
    {
        mRecipeNameText.text = pRecipeSO.mRecipeName;
    }

    [SerializeField]
    private TextMeshProUGUI mRecipeNameText;
}
