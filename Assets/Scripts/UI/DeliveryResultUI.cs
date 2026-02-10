using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        DeliveryManager.mInstance.mOnRecipeSuccess += DeliveryManager_mOnRecipeSuccess;
        DeliveryManager.mInstance.mOnRecipeFailed += DeliveryManager_mOnRecipeFailed;

        hide();
    }
    private void DeliveryManager_mOnRecipeFailed(object sender, System.EventArgs e)
    {
        hide();
        show(); mAnimator.ResetTrigger(POPUP_STRING);
        mAnimator.SetTrigger(POPUP_STRING);
        mBackgroundImage.color = mFailedColor;
        mIconSuccessImage.sprite = mFailedSprite;
        mText.text = "Delivery\nFailed";
    }
    private void DeliveryManager_mOnRecipeSuccess(object sender, System.EventArgs e)
    {
        hide();
        show();
        mAnimator.ResetTrigger(POPUP_STRING);
        mAnimator.SetTrigger(POPUP_STRING);
        mBackgroundImage.color = mSuccessColor;
        mIconSuccessImage.sprite = mSuccessSprite;
        mText.text = "Delivery\nSuccess";
    }
    private void hide()
    {
        gameObject.SetActive(false);
    }
    private void show()
    {
        gameObject.SetActive(true);
    }

    [SerializeField]
    private Image mBackgroundImage;
    [SerializeField]
    private Image mIconSuccessImage;
    [SerializeField]
    private TextMeshProUGUI mText;
    [SerializeField]
    private Color mSuccessColor;
    [SerializeField]
    private Color mFailedColor;
    [SerializeField]
    private Sprite mSuccessSprite;
    [SerializeField]
    private Sprite mFailedSprite;

    private const string POPUP_STRING = "Popup";
    private Animator mAnimator;
}
