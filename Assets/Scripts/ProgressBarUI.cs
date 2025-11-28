using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    private void Start()
    {
        mIHasProgress = mGameObjectForProgress.GetComponent<IHasProgress>();
        if (mIHasProgress == null)
            Debug.LogError("Object " + mIHasProgress + " is null!");

        mIHasProgress.mOnBarChanged += MIHasProgress_mOnBarChanged;

        mBarImage.fillAmount = 0.0f;
        
        hide();
    }
    
    private void MIHasProgress_mOnBarChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        mBarImage.fillAmount = e.mProgressFloat;
        if (e.mProgressFloat == 0.0f)
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
    private GameObject mGameObjectForProgress;

    private IHasProgress mIHasProgress;
}
