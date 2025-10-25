using UnityEngine;

public class Select : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.mOnSelectedCounter += Player_mOnSelectedCounter;
    }

    private void Player_mOnSelectedCounter(object sender, Player.OnSelectedCounterEventArgs events)
    {
        if (events.mSelectedCounter == mClearCounter)
            Show();
        else
            Hide();
    }

    private void Show()
    {
        mVisualGameObject.SetActive(true);
    }
    private void Hide()
    {
        mVisualGameObject.SetActive(false);
    }

    [SerializeField]
    private ClearCounter mClearCounter;
    [SerializeField]
    private GameObject mVisualGameObject;
}
