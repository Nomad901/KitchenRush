using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void interact(Player pPlayer)
    {
        if(pPlayer.hasKitchenObject())
        {
            if(pPlayer.getKitchenObject().tryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                pPlayer.getKitchenObject().destroySelf();
            }
        }
    }
}
