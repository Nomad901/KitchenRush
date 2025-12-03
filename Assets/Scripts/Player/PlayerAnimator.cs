using Mono.Cecil.Cil;
using System.Collections;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

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
        if(mPlayer.getPlayerMovement().isWalking())
        {
            if (mPlayer.hasKitchenObject())
                changeAnimation("MoveKeepingObject");
            else 
                changeAnimation("Walk");
        }
        else
        {
            if (mPlayer.hasKitchenObject())
                changeAnimation("IdleKeepingObject");
            else 
                changeAnimation("Idle");
        }
    }
    public void changeAnimation(string pNameOfAnimation, float pCrossFade = 0.2f, float pTime = 0.0f)
    {
        if (mCurrentAnimation != pNameOfAnimation)
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
