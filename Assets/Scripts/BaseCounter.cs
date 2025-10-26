using UnityEngine;

public class BaseCounter : MonoBehaviour
{
    public virtual void interact(Player pPlayer)
    {
        Debug.Log("Im in interact!");
    }
}
