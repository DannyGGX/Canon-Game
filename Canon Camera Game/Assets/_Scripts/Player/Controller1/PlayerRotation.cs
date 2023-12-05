using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerStatsSO playerStats;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private Transform playerTransform;
    private Camera mainCamera;

    private float verticalRotation = 0;
    private float horizontalRotation = 0;
    [SerializeField] private float upDownRange = 90;

    private void Awake()
    {
        mainCamera = Camera.main; // Cache camera so that the main camera only needs to be found once.
#if UNITY_STANDALONE
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
#endif
    }


    void FixedUpdate()
    {
        ApplyHorizontalRotation();
        ApplyVerticalRotation();
    }

    private void ApplyHorizontalRotation()
    {
        
        horizontalRotation = playerInput.xMouseInput * playerStats.MouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);
    }

    private void ApplyVerticalRotation()
    {
        verticalRotation -= playerInput.yMouseInput * playerStats.MouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
