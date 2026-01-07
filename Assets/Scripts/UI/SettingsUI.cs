using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    private void Awake()
    {
        mTimeSlider.value = GameSettings.mGamePlayingTimerMax / 1000.0f;
        mTextTimer.text = GameSettings.mGamePlayingTimerMax.ToString();

        mBackButton.onClick.AddListener(() =>
        {
            Loader.loadScene(Loader.Scenes.GameMenuScene);
        });
        mTimeSlider.onValueChanged.AddListener((float pValue) =>
        {
            float time = Mathf.Min(Mathf.Ceil(pValue * 1000.0f), 999.0f);
            GameSettings.mGamePlayingTimerMax = time;
            mTextTimer.text = time.ToString();
        });
    }

    [SerializeField]
    private Button mBackButton;
    [SerializeField]
    private Slider mTimeSlider;
    [SerializeField]
    private TextMeshProUGUI mTextTimer;
}
