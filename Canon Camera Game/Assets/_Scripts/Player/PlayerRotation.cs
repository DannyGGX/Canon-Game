using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerStatsSO playerStats;
    private Camera mainCamera;

    private float verticalRotation = 0;
    private float horizontalRotation = 0;
    [SerializeField] private float UpDownRange = 60;

    private void Awake()
    {
        mainCamera = Camera.main; // Cache camera so that the main camera only needs to be found once.
    }


    void Update()
    {
        ApplyHorizontalRotation();
        ApplyVerticalRotation();
    }

    private void ApplyHorizontalRotation()
    {
        horizontalRotation = Input.GetAxis("Mouse X") * playerStats.MouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);
    }

    private void ApplyVerticalRotation()
    {
        verticalRotation -= Input.GetAxis("Mouse Y") * playerStats.MouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -UpDownRange, UpDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
