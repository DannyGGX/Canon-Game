using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAim : MonoBehaviour
{
    [SerializeField] private Vector3 downPosition;
    [SerializeField] private Quaternion downRotation;
    [SerializeField] private Vector3 aimPosition;
    [SerializeField] private Quaternion aimRotation;

    private void OnEnable()
    {
        EventManager.OnAimCamera.Subscribe(AimCamera);
        EventManager.OnLowerCamera.Subscribe(LowerCamera);
    }

    private void OnDisable()
    {
        EventManager.OnAimCamera.Unsubscribe(AimCamera);
        EventManager.OnLowerCamera.Unsubscribe(LowerCamera);
    }

    private void AimCamera()
    {
        transform.localPosition = aimPosition;
        transform.localRotation = aimRotation;
    }

    private void LowerCamera()
    {
        transform.localPosition = downPosition;
        transform.localRotation = downRotation;
    }
}
