using UnityEngine;

[CreateAssetMenu()]
public class AudioClipRefSO : ScriptableObject
{
    public AudioClip[] mChop;
    public AudioClip[] mDeliveryFail;
    public AudioClip[] mDeliverySuccess;
    public AudioClip[] mFootstep;
    public AudioClip[] mObjectDrop;
    public AudioClip[] mObjectPickUp;
    public AudioClip[] mTrash;
    public AudioClip[] mWarning;
    public AudioClip mStoveSizzle;
}
