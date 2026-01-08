using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangerOfTime : MonoBehaviour
{
    private void Awake()
    {
        mTimeSlider.value = GameSettings.mGamePlayingTimerMax / 1000.0f;
        mTextTimer.text = GameSettings.mGamePlayingTimerMax.ToString();

        mTimeSlider.onValueChanged.AddListener((float pValue) =>
        {
            float time = Mathf.Min(Mathf.Ceil(pValue * 1000.0f), 999.0f);
            GameSettings.mGamePlayingTimerMax = time;
            mTextTimer.text = time.ToString(); 
        });
    }

    [SerializeField]
    private Slider mTimeSlider;
    [SerializeField]
    private TextMeshProUGUI mTextTimer;
}
