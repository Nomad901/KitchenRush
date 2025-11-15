using UnityEngine;
using UnityEngine.Rendering;

public class CutCounter : BaseCounter
{
    public override void interact(Player pPlayer)
    {
        if (!hasKitchenObject())
        {
            if (pPlayer.hasKitchenObject())
                pPlayer.getKitchenObject().setKitchenObjectParent(this);
        }
        else
        {
            if (!pPlayer.hasKitchenObject())
                getKitchenObject().setKitchenObjectParent(pPlayer);
        }
    }

    public override void interactAlternate(Player pPlayer)
    {
        if(hasKitchenObject())
        {
            getKitchenObject().destroySelf();

            KitchenObject.spawnKitchenObject(mKitchenScriptObject, this);
        }
    }

    [SerializeField]
    private KitchenScriptObject mKitchenScriptObject;

}
