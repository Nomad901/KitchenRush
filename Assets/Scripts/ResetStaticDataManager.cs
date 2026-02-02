using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour
{
    private void Awake()
    {
        CutCounter.resetStaticData();
        BaseCounter.resetStaticData();
        TrashCounter.resetStaticData();
    }
}
