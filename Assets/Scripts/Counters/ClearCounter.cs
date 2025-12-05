using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ClearCounter : BaseCounter
{
    public override void interact(Player pPlayer)
    {
        if(!hasKitchenObject())
        {
            if (pPlayer.hasKitchenObject())
                pPlayer.getKitchenObject().setKitchenObjectParent(this);
        }
        else
        {
            if(!pPlayer.hasKitchenObject())
                getKitchenObject().setKitchenObjectParent(pPlayer);
            else
            {
                if(pPlayer.getKitchenObject() is PlateKitchenObject)
                {
                    PlateKitchenObject plate = pPlayer.getKitchenObject() as PlateKitchenObject;
                    if(plate.tryAddIngredient(getKitchenObject().getKitchenScriptObject()))
                        getKitchenObject().destroySelf();
                }
            }
        }
    }

    [SerializeField] 
    private KitchenScriptObject mKitchenScriptObject;
}
