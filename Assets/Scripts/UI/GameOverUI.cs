using System;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    private void Start()
    {
        GameHandler.mInstance.mOnStateChanged += GameHandler_mOnStateChanged;
        hide();
    }
    private void GameHandler_mOnStateChanged(object sender, System.EventArgs e)
    {
        if (GameHandler.mInstance.isGameOver())
        {
            show();
            mRecipesDeliveredText.text = DeliveryManager.mInstance.getSuccessfulRecipeQuantity().ToString();
        }
        else
            hide();
    }
    private void show()
    {
        gameObject.SetActive(true);
    }
    private void hide()
    {
        gameObject.SetActive(false);
    }

    [SerializeField]
    private TextMeshProUGUI mRecipesDeliveredText;
}
