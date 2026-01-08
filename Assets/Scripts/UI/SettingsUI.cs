using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SettingsUI : MonoBehaviour
{
    private void Awake()
    {
        mBackButton.onClick.AddListener(() =>
        {
            Loader.loadScene(Loader.Scenes.GameMenuScene);
        });
    }

    [SerializeField]
    private UnityEngine.UI.Button mBackButton;
}
