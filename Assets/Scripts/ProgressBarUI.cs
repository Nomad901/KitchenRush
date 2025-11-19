using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    private void Start()
    {
        mCutCounter.mOnBarChanged += MCutCounter_mOnBarChanged;

        mBarImage.fillAmount = 0.0f;

        hide();
    }

    private void MCutCounter_mOnBarChanged(object sender, CutCounter.OnProgressChangedEventArgs e)
    {
        mBarImage.fillAmount = e.mProgressFloat;
        if (e.mProgressFloat == 0.0f || e.mProgressFloat == 0.0f)
            hide();
        else
            show();
    }

    private void hide()
    {
        gameObject.SetActive(false);
    }
    private void show()
    {
        gameObject.SetActive(true);
    }

    [SerializeField]
    private Image mBarImage;
    [SerializeField]
    private CutCounter mCutCounter;
}
