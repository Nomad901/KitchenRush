using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private void Awake()
    {
        mAnimator = GetComponent<Animator>();
    }
    private void Start()
    {
        mContainerCounter.mOnGrabbedKitchenObject += MContainerCounter_mOnGrabbedKitchenObject;
    }

    private void MContainerCounter_mOnGrabbedKitchenObject(object sender, System.EventArgs e)
    {
        mAnimator.SetTrigger(OPEN_CLOSE);
    }

    [SerializeField]
    private ContainerCounter mContainerCounter;

    private Animator mAnimator;
    private const string OPEN_CLOSE = "OpenClose";
}
