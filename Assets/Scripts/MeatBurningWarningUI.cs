using UnityEngine;

public class MeatBurningWarningUI : MonoBehaviour
{
    private void Start()
    {
        mStoveCounter.mOnBarChanged += MStoveCounter_mOnBarChanged;
        
        hide();
    }
    private void MStoveCounter_mOnBarChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burntWarningProgressOn = 0.5f;
        bool showCond = mStoveCounter.isFried() && e.mProgressFloat >= burntWarningProgressOn;

        if (showCond)
            show();
        else
            hide();
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
    private StoveCounter mStoveCounter;
}
