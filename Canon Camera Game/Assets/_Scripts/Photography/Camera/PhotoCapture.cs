using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoCapture : MonoBehaviour
{
    [SerializeField] private int albumSize = 128;
    
    private void OnEnable()
    {
        EventManager.OnTakePhoto.Subscribe(TakePhoto);
    }

    private void OnDisable()
    {
        EventManager.OnTakePhoto.Unsubscribe(TakePhoto);
    }

    private void TakePhoto()
    {
        
    }
}
