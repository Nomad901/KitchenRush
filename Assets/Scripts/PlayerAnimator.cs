using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        mAnimator.SetBool(IS_WALKING, mPlayer.getPlayerMovement().isWalking());
        checkAnimation(mPlayer.getPlayerInteractions().getGameInput());
    }
    public void checkAnimation(GameInput pGameInput)
    {
        if(pGameInput.getPlayerInputActions().Player.Interact.activeControl?.name == "e")
        {
            changeAnimation("takeObject");
        }
        else if(mPlayer.getPlayerMovement().isWalking())
        {
            changeAnimation("Walk");
        }
        else
        {
            changeAnimation("Idle");
        }
    }
    public void changeAnimation(string pNameOfAnimation, float pCrossFade = 0.2f)
    {
        if(mCurrentAnimation != pNameOfAnimation)
        {
            mCurrentAnimation = pNameOfAnimation;
            mAnimator.CrossFade(pNameOfAnimation, pCrossFade);
        }
    }

    [SerializeField]
    private Player mPlayer;

    private Animator mAnimator;
    private const string IS_WALKING = "IsWalking";
    private string mCurrentAnimation = "";
}
