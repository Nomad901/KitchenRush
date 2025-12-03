using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    public KitchenScriptObject mInput;
    public KitchenScriptObject mOutput;
    public float mFryingTimerMax;
}
