using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public static void loadScene(Scenes pTargetScene)
    {
        mTargetScene = pTargetScene;
        if (pTargetScene == Scenes.SettingsScene)
            SceneManager.LoadScene(Scenes.SettingsScene.ToString());
        else if (pTargetScene == Scenes.GameMenuScene)
            SceneManager.LoadScene(Scenes.GameMenuScene.ToString());
        else
            SceneManager.LoadScene(Scenes.LoadingScene.ToString());
    }

    public static void loadCallBack()
    {
        SceneManager.LoadScene(mTargetScene.ToString());
    }

    public enum Scenes
    {
        GameScene = 0,
        GameMenuScene = 1,
        LoadingScene = 2,
        SettingsScene = 3
    };
    private static Scenes mTargetScene;
}
