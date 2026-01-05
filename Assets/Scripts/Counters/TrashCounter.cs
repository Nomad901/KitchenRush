using System;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TrashCounter : BaseCounter
{
    private void Awake()
    {
        mInstance = this;
    }
    public override void interact(Player pPlayer)
    {
        if (pPlayer.hasKitchenObject())
        {
            Destroy(pPlayer.getKitchenObject().gameObject);
            mOnTrashInteract?.Invoke(this, EventArgs.Empty);
        }
    }

    public static TrashCounter mInstance { get; private set; }

    public event EventHandler mOnTrashInteract;
}
