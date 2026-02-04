using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerTimeOfNextOrderUI : MonoBehaviour
{
    private void Awake()
    {
        mTimeSlider.value = GameSettings.mTimerOfNextOrder / 100.0f;
        mTextTimer.text = GameSettings.mTimerOfNextOrder.ToString();

        mTimeSlider.onValueChanged.AddListener((float pValue) =>
        {
            float time = Mathf.Min(Mathf.Ceil(pValue * 100.0f), GameSettings.mGamePlayingTimerMax);
            GameSettings.mTimerOfNextOrder = time;
            mTextTimer.text = time.ToString();
        });
    }

    [SerializeField]
    private Slider mTimeSlider;
    [SerializeField]
    private TextMeshProUGUI mTextTimer;
}
