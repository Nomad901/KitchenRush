using System;
using Unity.Mathematics;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void Awake()
    {
        mInstance = this;
    }
    private void Start()
    {
        DeliveryManager.mInstance.mOnRecipeSuccess +=  DeliveryManager_mOnRecipeSuccess;
        DeliveryManager.mInstance.mOnRecipeFailed += DeliveryManager_mOnRecipeFailed;

        CutCounter.mOnAnyCut += CutCounter_mOnAnyCut;

        Player.mOnPickUp += Player_mOnPickUp;
        BaseCounter.mOnAnyObjectPut += BaseCounter_mOnAnyObjectPut;
        TrashCounter.mOnTrashInteract += TrashCounter_mOnTrashInteract;
    }
    private void TrashCounter_mOnTrashInteract(object sender, EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        playSound(mAudioClipRefSO.mTrash, trashCounter.transform.position);
    }
    private void BaseCounter_mOnAnyObjectPut(object sender, EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        playSound(mAudioClipRefSO.mObjectDrop, baseCounter.transform.position);
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
    private void playSound(AudioClip pAudioClip, Vector3 pPosOfAudio, float pVolumeMultiplier = 1.0f)
    {
        AudioSource.PlayClipAtPoint(pAudioClip, pPosOfAudio, mVolume * pVolumeMultiplier);
    }
    public void playFootStepAudio(Vector3 pPos, float pVolume)
    {
        playSound(mAudioClipRefSO.mFootstep, pPos, pVolume);
    }
    public void changeVolume()
    {
        mVolume += 0.1f;
        if(mVolume > 1.0f)
            mVolume = 0.0f;   
    }
    public float getVolume()
    {
        return mVolume;
    }

    [SerializeField]
    private AudioClipRefSO mAudioClipRefSO;

    private float mVolume = 1.0f;

    public static SoundManager mInstance { get; private set; }
}
