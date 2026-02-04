using UnityEngine;

public class LoaderCallBack : MonoBehaviour
{
    private void Update()
    {
        if (mIsFirstUpdate)
        { 
            mIsFirstUpdate = false;
            Loader.loadCallBack();
        }
    }

    private bool mIsFirstUpdate = true;
}
