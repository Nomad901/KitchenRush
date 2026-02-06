using System;
using System.Net.Mail;
using TMPro;
using UnityEngine;

public class GameStartCountDownUI : MonoBehaviour
{
    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        GameHandler.mInstance.mOnStateChanged += GameHandler_mOnStateChanged;
        hide();
    }
    private void GameHandler_mOnStateChanged(object sender, System.EventArgs e)
    {
        if (GameHandler.mInstance.isCountDownToStartActive())
            show();
        else
            hide();
    }
    private void Update()
    {
        Int32 countDownInt = Mathf.CeilToInt(GameHandler.mInstance.getCountDownTimer());
        mCountDownText.text = countDownInt.ToString();

        if(mPreviousNumber != countDownInt)
        {
            mPreviousNumber = countDownInt;
            mAnimator.SetTrigger(ANIMATOR_TRIGGER_STRING);
            SoundManager.mInstance.playCountDownAudio();
        }
    }

    private void show()
    {
        gameObject.SetActive(true);
    }
    private void hide()
    {
        gameObject.SetActive(false);
    }

    [SerializeField]
    private TextMeshProUGUI mCountDownText;

    private const string ANIMATOR_TRIGGER_STRING = "NumberPopUp";
    private Animator mAnimator;
    private Int32 mPreviousNumber = 0;
}
