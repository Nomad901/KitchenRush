using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    private void Awake()
    {
        mPlayButton.onClick.AddListener(() =>
        {
            Loader.loadScene(Loader.Scenes.GameScene);
        });
        mSettingsButton.onClick.AddListener(() =>
        {
            Loader.loadScene(Loader.Scenes.SettingsScene);
        });
        mQuitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });

        Time.timeScale = 1.0f;
    }

    [SerializeField]
    private Button mPlayButton;
    [SerializeField]
    private Button mSettingsButton;
    [SerializeField]
    private Button mQuitButton;

}
