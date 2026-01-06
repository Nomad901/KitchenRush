using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameHandler : MonoBehaviour
{
    private void Awake()
    {
        mInstance = this;
        mCurrentState = State.WAITING_TO_START;
    }
    private void Update()
    {
        switch(mCurrentState)
        {
            case State.WAITING_TO_START:
                mWaitingToStartTimer -= Time.deltaTime;
                if (mWaitingToStartTimer < 0.0f)
                {
                    mCurrentState = State.COUNT_DOWN_TO_START;
                    mOnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.COUNT_DOWN_TO_START:
                mCountDownToStartTimer -= Time.deltaTime;
                if (mCountDownToStartTimer < 0.0f)
                {
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

    private enum State
    { 
        WAITING_TO_START    = 0,
        COUNT_DOWN_TO_START = 1,
        GAME_PLAYING        = 2,
        GAME_OVER           = 3
    }
    private State mCurrentState;

    private float mWaitingToStartTimer = 1.0f;
    private float mCountDownToStartTimer = 3.0f;
    private float mGamePlayingTimer = 10.0f;

    public static GameHandler mInstance { get; private set; }

    public event EventHandler mOnStateChanged;
}
