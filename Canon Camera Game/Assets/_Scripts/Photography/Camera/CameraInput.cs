using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInput : MonoBehaviour
{

    private bool isCameraAimed = false;

    private void Update()
    {
        if (isCameraAimed)
        {
            if (Input.GetMouseButtonDown(0))
            {
                EventManager.OnTakePhoto.Invoke();
            }
            else if (Input.GetMouseButtonDown(1))
            {
                EventManager.OnLowerCamera.Invoke();
                isCameraAimed = false;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(1))
            {
                EventManager.OnAimCamera.Invoke();
                isCameraAimed = true;
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
            {
                EventManager.OnChangeLens.Invoke(true);
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0) // backward
            {
                EventManager.OnChangeLens.Invoke(false);
            }
        }

    }
    
    
}
