using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPauseUI : MonoBehaviour
{
    private void Awake()
    {
        mInstance = this;

        mSoundsEffectButtons.onClick.AddListener(() =>
        {
            SoundManager.mInstance.changeVolume();
            updateVisuals();
        });
        mMusicButton.onClick.AddListener(() =>
        {
            MusicManager.mInstance.changeVolume();
            updateVisuals();
        });
        mCloseButton.onClick.AddListener(() =>
        {
            hide();
        });
        mMoveUpButton.onClick.AddListener(() =>
        {
            GameInput.mInstance.rebindKey(GameInput.KeyBindings.MOVE_UP);
        });
    }
    private void Start()
    {
        GameHandler.mInstance.mOnGameUnPaused += GameHandler_mOnGameUnPaused;
     
        updateVisuals();
        hide();
        hideRebindKeyWindow();
    }
    private void GameHandler_mOnGameUnPaused(object sender, EventArgs e)
    {
        hide();
    }
    public void updateVisuals()
    {
        mSoundsEffectText.text = "Sound effects: " + MathF.Round(SoundManager.mInstance.getVolume() * 10.0f);
        mMusicText.text = "Music: " + Mathf.Round(MusicManager.mInstance.getVolume() * 10.0f);

        mMoveUpText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.MOVE_UP);
        mMoveDownText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.MOVE_DOWN);
        mMoveRightText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.MOVE_RIGHT);
        mMoveLeftText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.MOVE_LEFT);
        mInteractText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.INTERACT);
        mInteractAltText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.INTERACT_ALT);
        mPauseText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.PAUSE);
    }
    public void show()
    {
        gameObject.SetActive(true);
    }
    public void hide()
    {
        gameObject.SetActive(false);
    }
    public void showRebindKeyWindow()
    {
        mWindowToRebindKey.gameObject.SetActive(true);
    }
    public void hideRebindKeyWindow()
    {
        mWindowToRebindKey.gameObject.SetActive(false);
    }

    [SerializeField]
    private Button mSoundsEffectButtons;
    [SerializeField]
    private Button mMusicButton;
    [SerializeField]
    private Button mCloseButton;
    [SerializeField]
    private Button mMoveUpButton;
    [SerializeField]
    private Button mMoveDownButton;
    [SerializeField]
    private Button mMoveRightButton;
    [SerializeField]
    private Button mMoveLeftButton;
    [SerializeField]
    private Button mInteractButton;
    [SerializeField]
    private Button mInteractAltButton;
    [SerializeField]
    private Button mPauseButton;

    [SerializeField]
    private TextMeshProUGUI mSoundsEffectText;
    [SerializeField]
    private TextMeshProUGUI mMusicText;
    [SerializeField]
    private TextMeshProUGUI mMoveUpText;
    [SerializeField]
    private TextMeshProUGUI mMoveDownText;
    [SerializeField]
    private TextMeshProUGUI mMoveRightText;
    [SerializeField]
    private TextMeshProUGUI mMoveLeftText;
    [SerializeField]
    private TextMeshProUGUI mInteractText;
    [SerializeField]
    private TextMeshProUGUI mInteractAltText;
    [SerializeField]
    private TextMeshProUGUI mPauseText;

    [SerializeField]
    private Transform mWindowToRebindKey;

    public static SettingsPauseUI mInstance { get; private set; }
}
