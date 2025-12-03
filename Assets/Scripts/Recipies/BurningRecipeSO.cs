using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject
{
    public KitchenScriptObject mInput;
    public KitchenScriptObject mOutput;
    public float mBurningTimerMax;
}
