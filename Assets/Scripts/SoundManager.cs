using System;
using Unity.Mathematics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void Start()
    {
        DeliveryManager.mInstance.mOnRecipeSuccess +=  DeliveryManager_mOnRecipeSuccess;
        DeliveryManager.mInstance.mOnRecipeFailed += DeliveryManager_mOnRecipeFailed;

        CutCounter.mOnAnyCut += CutCounter_mOnAnyCut;

        Player.mOnPickUp += Player_mOnPickUp;
        Player.mOnDrop += Player_mOnDrop;
        PlayerMovement.mOnFootStep += PlayerMovement_mOnFootStep;

        TrashCounter.mInstance.mOnTrashInteract += MInstance_mOnTrashInteract;

    }
    private void MInstance_mOnTrashInteract(object sender, EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        playSound(mAudioClipRefSO.mTrash, trashCounter.transform.position);
    }
    private void Player_mOnDrop(object sender, EventArgs e)
    {
        Player player = sender as Player;
        playSound(mAudioClipRefSO.mObjectDrop, player.transform.position);
    }
    private void PlayerMovement_mOnFootStep(object sender, EventArgs e)
    {
        PlayerMovement playerMovement = sender as PlayerMovement;
        playSound(mAudioClipRefSO.mFootstep, playerMovement.getTransform().position);
    }
    private void Player_mOnPickUp(object sender, EventArgs e)
    {
        Player player = sender as Player;
        playSound(mAudioClipRefSO.mObjectPickUp, player.transform.position);
    }
    private void CutCounter_mOnAnyCut(object sender, EventArgs e)
    {
        CutCounter cutCounter = sender as CutCounter;
        playSound(mAudioClipRefSO.mChop, cutCounter.transform.position);
    }
    private void DeliveryManager_mOnRecipeFailed(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.mInstance;
        playSound(mAudioClipRefSO.mDeliveryFail, deliveryCounter.transform.position);
    }
    private void DeliveryManager_mOnRecipeSuccess(object sender, System.EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.mInstance;
        playSound(mAudioClipRefSO.mDeliverySuccess, deliveryCounter.transform.position);
    }
    private void playSound(AudioClip[] pAudioClipArray, Vector3 pPosOfAudio, float pVolume = 1.0f)
    {
        Int32 randomIndex = UnityEngine.Random.Range(0, pAudioClipArray.Length);
        playSound(pAudioClipArray[randomIndex], pPosOfAudio, pVolume);
    }
    private void playSound(AudioClip pAudioClip, Vector3 pPosOfAudio, float pVolume = 1.0f)
    {
        AudioSource.PlayClipAtPoint(pAudioClip, pPosOfAudio, pVolume);
    }

    [SerializeField]
    private AudioClipRefSO mAudioClipRefSO;

}
