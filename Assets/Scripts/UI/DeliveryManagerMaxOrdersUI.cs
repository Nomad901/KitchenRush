using System;
using TMPro;
using TMPro.EditorUtilities;
using UnityEditor.UI;
using UnityEngine;

public class DeliveryManagerMaxOrdersUI : MonoBehaviour
{
    private void Awake()
    {
        mInputFieldEditor.onSubmit.AddListener((string pString) =>
        {
            if(Int32.TryParse(pString, out Int32 value))
            {
                GameSettings.mWaitingRecipesMax = value;
                mInputFieldEditor.text = "";
                mText.text = "Success!";
            } 
            else
            {
                mInputFieldEditor.text = "";
                mText.text = "Nothing happened...";
            }
        });
    }

    [SerializeField]
    private TMP_InputField mInputFieldEditor;
    [SerializeField]
    private TextMeshProUGUI mText;
}
