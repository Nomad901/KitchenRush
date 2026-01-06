using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    private void Awake()
    {
        mAudioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        mStoveCounter.mOnStateChange += MStoveCounter_mOnStateChange;
    }

    private void MStoveCounter_mOnStateChange(object sender, StoveCounter.OnStateChangeArgs e)
    {
        bool playSound = e.mState == StoveCounter.fryingState.FRYING ||
                         e.mState == StoveCounter.fryingState.FRIED;
        if (playSound)
            mAudioSource.Play();
        else
            mAudioSource.Pause();
    }

    [SerializeField]
    private StoveCounter mStoveCounter;

    private AudioSource mAudioSource;
}
