using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveObject : MonoBehaviour
{
    public ObjectiveObjectNames Name;
    private bool isGroundLayer;

    private void Awake()
    {
        if (gameObject.layer == LayerMask.NameToLayer("ObjectiveWalkable"))
            isGroundLayer = true;
        else
            isGroundLayer = false;

        
    }

    public void RemoveObjectiveObject()
    {
        if (isGroundLayer)
        {
            gameObject.layer = LayerMask.NameToLayer("Ground");
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
        
    }
}
