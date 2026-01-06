using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private void Awake()
    {
        mPlayer = GetComponent<Player>();
    }

    private void Update()
    {
        mFootStepTimer -= Time.deltaTime;
        if(mFootStepTimer < 0.0f)
        {
            mFootStepTimer = FOOT_STEP_TIMER_MAX;

            if(mPlayer.getPlayerMovement().isWalking())
            {
                float volume = 1.0f;
                SoundManager.mInstance.playFootStepAudio(mPlayer.transform.position, volume);
            }
        }
    }

    private Player mPlayer;
    private float mFootStepTimer;
    private const float FOOT_STEP_TIMER_MAX = 0.1f;
}
