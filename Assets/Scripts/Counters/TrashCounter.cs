using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class TrashCounter : BaseCounter
{
    public override void interact(Player pPlayer)
    {
        if (pPlayer.hasKitchenObject())
            Destroy(pPlayer.getKitchenObject().gameObject);
    }
}
