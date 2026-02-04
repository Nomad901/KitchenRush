using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        mInstance = this;
        mAudioSource = GetComponent<AudioSource>();

        mVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_STRING, 1.0f);
        mAudioSource.volume = mVolume;
    }
    public void changeVolume()
    {
        mVolume += 0.1f;
        if (mVolume > 1.0f)
            mVolume = 0.0f;
        mAudioSource.volume = mVolume;

        PlayerPrefs.SetFloat(MUSIC_VOLUME_STRING, mVolume);
        PlayerPrefs.Save();
    }
    public float getVolume()
    {
        return mVolume;
    }

    private float mVolume;
    private AudioSource mAudioSource;

    private const string MUSIC_VOLUME_STRING = "MusicVolume";

    public static MusicManager mInstance { get; private set; }
}