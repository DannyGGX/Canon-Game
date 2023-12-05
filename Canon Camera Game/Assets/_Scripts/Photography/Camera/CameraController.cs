using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera photographyCamera;
    
    private void OnEnable()
    {
        EventManager.OnAimCamera.Subscribe(AimCamera);
        EventManager.OnLowerCamera.Subscribe(LowerCamera);
        EventManager.OnTakePhoto.Subscribe(TakePhoto);

        photographyCamera.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        EventManager.OnAimCamera.Unsubscribe(AimCamera);
        EventManager.OnLowerCamera.Unsubscribe(LowerCamera);
        EventManager.OnTakePhoto.Unsubscribe(TakePhoto);
    }

    private void AimCamera()
    {
        photographyCamera.gameObject.SetActive(true);
    }

    private void LowerCamera()
    {
        photographyCamera.gameObject.SetActive(false);
    }

    private void TakePhoto()
    {
        
    }
}
