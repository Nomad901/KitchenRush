using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public override void interact(Player pPlayer)
    {
        if (!pPlayer.hasKitchenObject())
        {
            Transform kitchenObjectTransform = Instantiate(mKitchenScriptObject.mPrefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().setKitchenObjectParent(pPlayer);

            mOnGrabbedKitchenObject?.Invoke(this, EventArgs.Empty);
        }
    }

    [SerializeField]
    private KitchenScriptObject mKitchenScriptObject;

    public event EventHandler mOnGrabbedKitchenObject;
}
