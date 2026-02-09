using UnityEngine;

public class StoveCounterFlashingBarUi : MonoBehaviour
{
    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        mStoveCounter.mOnBarChanged += MStoveCounter_mOnBarChanged;

        mAnimator.SetBool(IS_FLASHING, false);
    }
    private void MStoveCounter_mOnBarChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burntWarningProgressOn = 0.5f;
        bool showCond = mStoveCounter.isFried() && e.mProgressFloat >= burntWarningProgressOn;

        mAnimator.SetBool(IS_FLASHING, showCond);
    }

    [SerializeField]
    private StoveCounter mStoveCounter;

    private Animator mAnimator;
    private const string IS_FLASHING = "isFlashing";
}
