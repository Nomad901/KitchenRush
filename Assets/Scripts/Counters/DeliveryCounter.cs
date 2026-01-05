using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    private void Start()
    {
        mInstance = this;
    }

    public override void interact(Player pPlayer)
    {
        if(pPlayer.hasKitchenObject())
        {
            if(pPlayer.getKitchenObject().tryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                DeliveryManager.mInstance.deliverPlate(plateKitchenObject);
                pPlayer.getKitchenObject().destroySelf();
            }
        }
    }

    public static DeliveryCounter mInstance { get; private set; }
}
