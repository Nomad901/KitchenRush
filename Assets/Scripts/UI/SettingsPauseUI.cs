using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI1 : MonoBehaviour
{
    private void Awake()
    {
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
    }
    private void Start()
    {
        updateVisuals();
    }
    public void updateVisuals()
    {
        mSoundsEffectText.text = "Sound effects: " + MathF.Round(SoundManager.mInstance.getVolume() * 10.0f);
        mMusicText.text = "Music: " + Mathf.Round(MusicManager.mInstance.getVolume() * 10.0f);
    }

    [SerializeField]
    private Button mSoundsEffectButtons;
    [SerializeField]
    private Button mMusicButton;
    [SerializeField]
    private TextMeshProUGUI mSoundsEffectText;
    [SerializeField]
    private TextMeshProUGUI mMusicText;

}
