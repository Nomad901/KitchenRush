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
            rebindBinding(GameInput.KeyBindings.MOVE_UP);
        });
        mMoveDownButton.onClick.AddListener(() =>
        {
            rebindBinding(GameInput.KeyBindings.MOVE_DOWN);
        });
        mMoveRightButton.onClick.AddListener(() =>
        {
            rebindBinding(GameInput.KeyBindings.MOVE_RIGHT);
        });
        mMoveLeftButton.onClick.AddListener(() =>
        {
            rebindBinding(GameInput.KeyBindings.MOVE_LEFT);
        });
        mInteractButton.onClick.AddListener(() =>
        {
            rebindBinding(GameInput.KeyBindings.INTERACT);
        });
        mInteractAltButton.onClick.AddListener(() =>
        {
            rebindBinding(GameInput.KeyBindings.INTERACT_ALT);
        });
        mPauseButton.onClick.AddListener(() =>
        {
            rebindBinding(GameInput.KeyBindings.PAUSE);
        });
        mGamepadInteractButton.onClick.AddListener(() =>
        {
            rebindBinding(GameInput.KeyBindings.GAMEPAD_INTERACT);
        });
        mGamepadInteractAltButton.onClick.AddListener(() =>
        {
            rebindBinding(GameInput.KeyBindings.GAMEPAD_INTERACT_ALT);
        });
        mGamepadPauseButton.onClick.AddListener(() =>
        {
            rebindBinding(GameInput.KeyBindings.GAMEPAD_PAUSE);
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
        mGamepadInteractText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.GAMEPAD_INTERACT);
        mGamepadInteractAltText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.GAMEPAD_INTERACT_ALT);
        mGamepadPauseText.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.GAMEPAD_PAUSE);

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
    private void rebindBinding(GameInput.KeyBindings pKeyBinding)
    {
        showRebindKeyWindow();
        GameInput.mInstance.rebindKey(pKeyBinding, () =>
            {
                hideRebindKeyWindow();
                updateVisuals();
            });
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
    private Button mGamepadInteractButton;
    [SerializeField]
    private Button mGamepadInteractAltButton;
    [SerializeField]
    private Button mGamepadPauseButton;

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
    private TextMeshProUGUI mGamepadInteractText;
    [SerializeField]
    private TextMeshProUGUI mGamepadInteractAltText;
    [SerializeField]
    private TextMeshProUGUI mGamepadPauseText;

    [SerializeField]
    private Transform mWindowToRebindKey;

    public static SettingsPauseUI mInstance { get; private set; }
}
