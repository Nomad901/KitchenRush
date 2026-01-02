using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void Start()
    {
        DeliveryManager.mInstance.mOnRecipeSuccess +=  DeliveryManager_mOnRecipeSuccess;
        DeliveryManager.mInstance.mOnRecipeFailed += DeliveryManager_mOnRecipeFailed;
    }

    private void DeliveryManager_mOnRecipeFailed(object sender, System.EventArgs e)
    {
        
    }

    private void DeliveryManager_mOnRecipeSuccess(object sender, System.EventArgs e)
    {

    }

    private void playSound(AudioClip pAudioClip, Vector3 pPosOfAudio, float pVolume = 1.0f)
    {
        AudioSource.PlayClipAtPoint(pAudioClip, pPosOfAudio, pVolume);
    }

}
