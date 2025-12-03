using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    private void Awake()
    {
        mPlatesVisuals = new List<GameObject>();
    }
    private void Start()
    {
        mPlateCounter.mOnPlateSpawned += PlateCounter_OnPlateSpawned;
        mPlateCounter.mOnPlateRemoved += PlateCounter_OnPlateRemoved;
    }
    private void PlateCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(mPlateVisualPrefab, mTopPoint);

        float plateOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0.0f, mPlatesVisuals.Count * plateOffsetY, 0.0f);
        
        mPlatesVisuals.Add(plateVisualTransform.gameObject);
    }
    private void PlateCounter_OnPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = mPlatesVisuals[mPlatesVisuals.Count - 1];
        mPlatesVisuals.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

    [SerializeField]
    private Transform mTopPoint;
    [SerializeField]
    private Transform mPlateVisualPrefab;
    [SerializeField]
    private PlateCounter mPlateCounter;

    private List<GameObject> mPlatesVisuals;
}
