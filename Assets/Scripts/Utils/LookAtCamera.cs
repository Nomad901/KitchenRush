using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        switch (mCameraMode)
        {
            case cameraMode.LOOK_AT:
                transform.LookAt(Camera.main.transform);
                break;
            case cameraMode.LOOK_AT_INVERTED:
                Vector3 dirFromCamera = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirFromCamera);
                break;
            case cameraMode.LOOK_AT_FORWARD:
                transform.forward = Camera.main.transform.forward;
                break;
            case cameraMode.LOOK_AT_FORWARD_INVERTED:
                transform.forward = -Camera.main.transform.forward;
                break;
            default:
                transform.forward = Camera.main.transform.forward;
                break;
        }
    }

    private enum cameraMode
    {
        LOOK_AT = 0,
        LOOK_AT_INVERTED = 1,
        LOOK_AT_FORWARD = 2,
        LOOK_AT_FORWARD_INVERTED = 3
    };

    [SerializeField]
    private cameraMode mCameraMode;
}
