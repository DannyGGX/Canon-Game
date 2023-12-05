using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectiveObject : MonoBehaviour
{
    public ObjectiveObjectNames Name;
    [SerializeField] private bool isWalkable;

    private void Awake()
    {
        SetTagsAndLayersOfObjects(isWalkable ? "ObjectiveWalkable" : "ObjectiveNonWalkable");
    }

    private void SetTagsAndLayersOfObjects(string layerName)
    {
        gameObject.layer = LayerMask.NameToLayer(layerName);
        
        if (transform.childCount == 0) return;

        foreach (Transform child in transform)
        {
            GameObject obj;
            (obj = child.gameObject).layer = LayerMask.NameToLayer(layerName);
            obj.tag = "ObjectiveChildObject";
        }
    }

    public void RemoveObjectiveObject()
    {
        SetTagsAndLayersOfObjects(isWalkable ? "Ground" : "Default");
        Destroy(this);
    }
}
