using Unity.VisualScripting;
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
        mStoveCounter.mOnBarChanged += MStoveCounter_mOnBarChanged;
    }
    private void Update()
    {
        if (mPlayWarningSoundCond)
        {
            mSoundWarningTimer -= Time.deltaTime;
            if (mSoundWarningTimer <= 0.0f)
            {
                mSoundWarningTimer = WARNING_SOUND_TIMER_MAX;

                SoundManager.mInstance.playWarningBurnAudio(mStoveCounter.transform.position);
            }
        }
    }
    private void MStoveCounter_mOnBarChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burntWarningProgressOn = 0.5f;
        mPlayWarningSoundCond = mStoveCounter.isFried() && e.mProgressFloat >= burntWarningProgressOn;
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

    private const float WARNING_SOUND_TIMER_MAX = 0.2f;
    private float mSoundWarningTimer = 0.0f;
    private bool mPlayWarningSoundCond;
}
