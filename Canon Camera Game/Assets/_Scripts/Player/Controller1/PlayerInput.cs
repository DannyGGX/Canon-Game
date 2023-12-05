using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerInput : MonoBehaviour
{
    public float xMouseInput;
    public float yMouseInput;

    public float xMoveInput;
    public float zMoveInput;

    public bool IsSprinting = false;
    public bool IsJumpPressed = false;
    
    private bool rotationEnabled = true;
    private bool movementEnabled = true;
    
    private void Update()
    {
        SetMouseInput();
        SetMovementInput();
        DetectJumpInput();
    }

    private void SetMouseInput()
    {
        if (rotationEnabled)
        {
            xMouseInput = Input.GetAxis("Mouse X") * Time.deltaTime;
            yMouseInput = Input.GetAxis("Mouse Y") * Time.deltaTime;
        }
    }

    private void SetMovementInput()
    {
        if (movementEnabled)
        {
            xMoveInput = Input.GetAxisRaw("Horizontal");
            zMoveInput = Input.GetAxisRaw("Vertical");

            if (zMoveInput > 0 && CheckSprintInput())
                IsSprinting = true;
            else
                IsSprinting = false;
        }
        else
        {
            xMoveInput = 0;
            yMouseInput = 0;
        }
    }

    private bool CheckSprintInput()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

    private void DetectJumpInput()
    {
        if (movementEnabled)
        {
            IsJumpPressed = Input.GetButton("Jump");
        }
        else
            IsJumpPressed = false;
    }
    
    public void EnableInput()
    {
        rotationEnabled = true;
        movementEnabled = true;
    }
    public void DisableInput()
    {
        rotationEnabled = false;
        movementEnabled = false;
    }

    public void EnableMoveInput()
    {
        movementEnabled = true;
    }
    public void DisableMoveInput()
    {
        movementEnabled = false;
    }
    
}
