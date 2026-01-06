using System;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TrashCounter : BaseCounter
{
    public override void interact(Player pPlayer)
    {
        if (pPlayer.hasKitchenObject())
        {
            pPlayer.getKitchenObject().destroySelf();
            mOnTrashInteract?.Invoke(this, EventArgs.Empty);
        }
    }

    public static event EventHandler mOnTrashInteract;
}
