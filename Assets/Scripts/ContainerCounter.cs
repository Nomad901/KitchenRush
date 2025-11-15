using System;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public override void interact(Player pPlayer)
    {
        if (!pPlayer.hasKitchenObject())
        {
            KitchenObject.spawnKitchenObject(mKitchenScriptObject, pPlayer);
            mOnGrabbedKitchenObject?.Invoke(this, EventArgs.Empty);
        }
    }

    [SerializeField]
    private KitchenScriptObject mKitchenScriptObject;

    public event EventHandler mOnGrabbedKitchenObject;
}
