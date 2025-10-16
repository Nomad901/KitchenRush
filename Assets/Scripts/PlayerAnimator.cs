using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        mAnimator.SetBool(IS_WALKING, mPlayer.isWalking());
    }

    // variables
    // ---------
    [SerializeField]
    private Player mPlayer;

    private Animator mAnimator;
    private const string IS_WALKING = "IsWalking";
    // ---------
}
