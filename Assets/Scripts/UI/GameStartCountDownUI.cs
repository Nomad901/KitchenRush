using System;
using TMPro;
using UnityEngine;

public class GameStartCountDownUI : MonoBehaviour
{
    private void Start()
    {
        GameHandler.mInstance.mOnStateChanged += GameHandler_mOnStateChanged;
        hide();
    }
    private void GameHandler_mOnStateChanged(object sender, System.EventArgs e)
    {
        if (GameHandler.mInstance.isCountDownToStartActive())
            show();
        else
            hide();
    }
    private void Update()
    {
        mCountDownText.text = MathF.Ceiling(GameHandler.mInstance.getCountDownTimer()).ToString();
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
    private TextMeshProUGUI mCountDownText;
}
