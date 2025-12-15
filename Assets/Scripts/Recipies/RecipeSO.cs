using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
    public List<KitchenScriptObject> mNeededKitchenObjects;
    public string mRecipeName;
}
