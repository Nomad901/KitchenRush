using UnityEngine;

public class ReadyTextUI : MonoBehaviour
{
    private void Start()
    {
        GameHandler.mInstance.mOnStateChanged += ReadyText_mOnStateChanged;
        hide();
    }

    private void ReadyText_mOnStateChanged(object sender, System.EventArgs e)
    {
        if (GameHandler.mInstance.isWaitingToStart())
            show();
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
}
