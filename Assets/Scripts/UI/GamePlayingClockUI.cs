using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    private void Update()
    {
        mTimerImage.fillAmount = GameHandler.mInstance.getGamePlayingTimerNormalized();
    }

    [SerializeField]
    private Image mTimerImage;
}