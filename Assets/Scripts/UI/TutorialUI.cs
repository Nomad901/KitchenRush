using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    private void Start()
    {
        GameInput.mInstance.mOnKeyRebinding += GameInput_mOnKeyRebinding;
        GameHandler.mInstance.mOnStateChanged += GameHandler_mOnStateChanged;
        updateVisuals();

        show();
    }

    private void GameHandler_mOnStateChanged(object sender, System.EventArgs e)
    {
        if (GameHandler.mInstance.isCountDownToStartActive())
            hide();
    }

    private void GameInput_mOnKeyRebinding(object sender, System.EventArgs e)
    {
        updateVisuals();
    }

    private void updateVisuals()
    {
        mKeyboardMoveUp.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.MOVE_UP);
        mKeyboardMoveLeft.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.MOVE_LEFT);
        mKeyboardMoveDown.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.MOVE_DOWN);
        mKeyboardMoveRight.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.MOVE_RIGHT);
        mKeyboardInteract.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.INTERACT);
        mKeyboardInteractAlt.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.INTERACT_ALT);
        mKeyboardPause.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.PAUSE);

        mGamepadInteract.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.GAMEPAD_INTERACT);
        mGamepadInteractAlt.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.GAMEPAD_INTERACT_ALT);
        mGamepadPause.text = GameInput.mInstance.getBindingKeyText(GameInput.KeyBindings.GAMEPAD_PAUSE);
    }

    private void show()
    {
        gameObject.SetActive(true);
    }
    private void hide()
    {
        gameObject.SetActive(false);
    }

    [SerializeField]
    private TextMeshProUGUI mKeyboardMoveUp;
    [SerializeField]
    private TextMeshProUGUI mKeyboardMoveLeft;
    [SerializeField]
    private TextMeshProUGUI mKeyboardMoveDown;
    [SerializeField]
    private TextMeshProUGUI mKeyboardMoveRight;
    [SerializeField]
    private TextMeshProUGUI mKeyboardInteract;
    [SerializeField]
    private TextMeshProUGUI mKeyboardInteractAlt;
    [SerializeField]
    private TextMeshProUGUI mKeyboardPause;

    [SerializeField]
    private TextMeshProUGUI mGamepadInteract;
    [SerializeField]
    private TextMeshProUGUI mGamepadInteractAlt;
    [SerializeField]
    private TextMeshProUGUI mGamepadPause;
}
