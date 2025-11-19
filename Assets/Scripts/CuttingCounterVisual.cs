using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        mCutCounter.mOnCut += MCutCounter_mOnCut;
    }

    private void MCutCounter_mOnCut(object sender, System.EventArgs e)
    {
        mAnimator.SetTrigger(CUT); 
    }

    [SerializeField]
    private CutCounter mCutCounter;

    private Animator mAnimator;
    private const string CUT = "Cut";
}
