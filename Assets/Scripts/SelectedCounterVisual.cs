using UnityEngine;

public class Select : MonoBehaviour
{
    private void Start()
    {
        Player.Instance.mOnSelectedCounter += Player_mOnSelectedCounter;
    }

    private void Player_mOnSelectedCounter(object sender, Player.OnSelectedCounterEventArgs events)
    {
        if (events.mBaseCounter == mBaseCounter)
            Show();
        else
            Hide();
    }

    private void Show()
    {
        foreach (var gameObject in mVisualGameObjects)
        {
            gameObject.SetActive(true);
        }
    }
    private void Hide()
    {
        foreach (var gameObject in mVisualGameObjects)
        {
            gameObject.SetActive(false);
        }
    }

    [SerializeField]
    private BaseCounter mBaseCounter;
    [SerializeField]
    private GameObject[] mVisualGameObjects;
}
