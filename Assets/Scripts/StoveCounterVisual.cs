using System;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    private void Start()
    {
        mStoveCounter.mOnStateChange += MStoveCounter_mOnStateChange;
    }

    private void MStoveCounter_mOnStateChange(object sender, StoveCounter.OnStateChangeArgs e)
    {
        switch (e.mState)
        {
            case StoveCounter.fryingState.FRYING:
                mVisuals[(int)VisualsType.FRYING_VISUAL].SetActive(true);
                mVisuals[(int)VisualsType.FRYING_PARTICLES].SetActive(true);
                break;
            case StoveCounter.fryingState.FRIED:
                if (mVisuals[(int)VisualsType.FRYING_VISUAL].activeInHierarchy)
                    hideVisuals();
                mVisuals[(int)VisualsType.FRIED_VISUAL].SetActive(true);
                mVisuals[(int)VisualsType.FRIED_PARTICLES].SetActive(true);
                break;
            case StoveCounter.fryingState.BURNED:
                if (mVisuals[(int)VisualsType.FRIED_VISUAL].activeInHierarchy)
                    hideVisuals();
                mVisuals[(int)VisualsType.BURNED_VISUAL].SetActive(true);
                mVisuals[(int)VisualsType.BURNED_PARTICLES].SetActive(true);
                break;
            default:
                if(mVisuals[(int)VisualsType.FRYING_VISUAL].activeInHierarchy ||
                   mVisuals[(int)VisualsType.FRIED_VISUAL].activeInHierarchy  ||
                   mVisuals[(int)VisualsType.BURNED_VISUAL].activeInHierarchy)
                {
                    hideVisuals();
                }
                break;
        }
    }
    
    private void hideVisuals()
    {
        foreach (var visual in mVisuals)
        {
            visual.SetActive(false);
        }
    }

    [SerializeField]
    private StoveCounter mStoveCounter;

    private enum VisualsType
    {
        FRYING_VISUAL = 0,
        FRYING_PARTICLES = 1,

        FRIED_VISUAL = 2,
        FRIED_PARTICLES = 3,

        BURNED_VISUAL = 4,
        BURNED_PARTICLES = 5,

        NUMBER_VISUALS = 6
    }

    [SerializeField]
    private GameObject[] mVisuals;
}
