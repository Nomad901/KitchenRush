using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        mInstance = this;
        mAudioSource = GetComponent<AudioSource>();
    }
    public void changeVolume()
    {
        mVolume += 0.1f;
        if (mVolume > 1.0f)
            mVolume = 0.0f;
        mAudioSource.volume = mVolume;
    }
    public float getVolume()
    {
        return mVolume;
    }

    private float mVolume;
    private AudioSource mAudioSource;

    public static MusicManager mInstance { get; private set; }
}