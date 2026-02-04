using System;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private void Awake()
    {
        mInstance = this;
        mCurrentState = State.WAITING_TO_START;
    }
    private void Start()
    {
        GameInput.mInstance.mOnPauseAction += MInstance_mOnPauseAction;
        GameInput.mInstance.mOnInteract += GameInput_mOnInteract;
    }

    private void GameInput_mOnInteract(object sender, EventArgs e)
    {
        if(mCurrentState == State.WAITING_TO_START)
        {
            mCurrentState = State.COUNT_DOWN_TO_START;
            mOnStateChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void MInstance_mOnPauseAction(object sender, EventArgs e)
    {
        pauseGame();
    }

    private void Update()
    {
        switch(mCurrentState)
        {
            case State.WAITING_TO_START:
                break;
            case State.COUNT_DOWN_TO_START:
                mCountDownToStartTimer -= Time.deltaTime;
                if (mCountDownToStartTimer < 0.0f)
                {
                    mGamePlayingTimer = GameSettings.mGamePlayingTimerMax;

                    mCurrentState = State.GAME_PLAYING;
                    mOnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GAME_PLAYING:
                mGamePlayingTimer -= Time.deltaTime;
                if (mGamePlayingTimer < 0.0f)
                {
                    mCurrentState = State.GAME_OVER;
                    mOnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GAME_OVER:
                break;
        }
    }
    public bool gameIsPlaying()
    {
        return mCurrentState == State.GAME_PLAYING;
    }
    public bool isCountDownToStartActive()
    {
        return mCurrentState == State.COUNT_DOWN_TO_START;
    }
    public bool isWaitingToStart()
    {
        return mCurrentState == State.WAITING_TO_START;
    }
    public bool isGameOver()
    {
        return mCurrentState == State.GAME_OVER;
    }
    public float getCountDownTimer()
    {
        return mCountDownToStartTimer;
    }
    public float getGamePlayingTimerNormalized()
    {
        return 1 - (mGamePlayingTimer / GameSettings.mGamePlayingTimerMax);
    }
    public void pauseGame()
    {
        mIsGamePaused = !mIsGamePaused;
        if(mIsGamePaused)
        {
            mOnGamePaused?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 0.0f;
        }
        else
        {
            mOnGameUnPaused?.Invoke(this, EventArgs.Empty);
            Time.timeScale = 1.0f;
        }
    }

    private enum State
    { 
        WAITING_TO_START    = 0,
        COUNT_DOWN_TO_START = 1,
        GAME_PLAYING        = 2,
        GAME_OVER           = 3
    }
    private State mCurrentState;

    private float mCountDownToStartTimer = 3.0f;
    private float mGamePlayingTimer;
    private bool mFirstTime = true;
    private bool mIsGamePaused = false;
    public static GameHandler mInstance { get; private set; }
    
    public event EventHandler mOnStateChanged;
    public event EventHandler mOnGamePaused;
    public event EventHandler mOnGameUnPaused;
}
