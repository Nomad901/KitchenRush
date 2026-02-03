using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void Awake()
    {
        mResumeButton.onClick.AddListener(() =>
        {
            GameHandler.mInstance.pauseGame();
        });
        mMenuButton.onClick.AddListener(() =>
        {
            Loader.loadScene(Loader.Scenes.GameMenuScene);
        });
        mSettingsButton.onClick.AddListener(() =>
        {
            hide();
            SettingsPauseUI.mInstance.show(show);
        });
    }
    private void Start()
    {
        GameHandler.mInstance.mOnGamePaused += GameHandler_mOnGamePaused;
        GameHandler.mInstance.mOnGameUnPaused += GameHandler_mOnGameUnPaused;

        hide();
    }

    private void GameHandler_mOnGameUnPaused(object sender, System.EventArgs e)
    {
        hide();
    }

    private void GameHandler_mOnGamePaused(object sender, System.EventArgs e)
    {
        show();
    }

    private void show()
    {
        gameObject.SetActive(true);

        mResumeButton.Select();
    }
    private void hide()
    {
        gameObject.SetActive(false);
    }

    [SerializeField]
    private Button mResumeButton;
    [SerializeField]
    private Button mSettingsButton;
    [SerializeField]
    private Button mMenuButton;
}
