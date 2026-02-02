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
    }
    private void Start()
    {
        GameHandler.mInstance.mOnGameUnPaused += GameHandler_mOnGameUnPaused;
     
        updateVisuals();
        hide();
    }
    private void GameHandler_mOnGameUnPaused(object sender, EventArgs e)
    {
        hide();
    }
    public void updateVisuals()
    {
        mSoundsEffectText.text = "Sound effects: " + MathF.Round(SoundManager.mInstance.getVolume() * 10.0f);
        mMusicText.text = "Music: " + Mathf.Round(MusicManager.mInstance.getVolume() * 10.0f);
    }
    public void show()
    {
        gameObject.SetActive(true);
    }
    public void hide()
    {
        gameObject.SetActive(false);
    }

    [SerializeField]
    private Button mSoundsEffectButtons;
    [SerializeField]
    private Button mMusicButton;
    [SerializeField]
    private Button mCloseButton;

    [SerializeField]
    private TextMeshProUGUI mSoundsEffectText;
    [SerializeField]
    private TextMeshProUGUI mMusicText;

    public static SettingsPauseUI mInstance { get; private set; }
}
