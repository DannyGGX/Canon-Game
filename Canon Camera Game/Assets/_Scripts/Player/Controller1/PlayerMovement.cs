using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Required Components")]
    [SerializeField] private PlayerStatsSO playerStats;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerInput playerInput;
    [Space]
    [Header("Ground Check")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private float groundCheckDistance = 0.5f;
    private bool isGrounded;

    private bool readyToJump = true;
    
    private float yMovement;
    private Vector3 horizontalMoveVector;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = transform;
    }

    private void FixedUpdate()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();
        ApplyMovement();
    }

    private void HandleHorizontalMovement()
    {
        //horizontalMoveVector = new Vector3(playerInput.xMoveInput, 0, playerInput.zMoveInput);
        horizontalMoveVector = playerTransform.forward * playerInput.zMoveInput + playerTransform.right * playerInput.xMoveInput;
        //horizontalMoveVector = horizontalMoveVector.normalized;
        if (playerInput.IsSprinting)
        {
            horizontalMoveVector.z *= playerStats.SprintSpeed;
            horizontalMoveVector.x *= playerStats.WalkSpeed;
        }
        else
        {
            horizontalMoveVector *= playerStats.WalkSpeed;
        }
    }
    private void HandleVerticalMovement()
    {
        isGrounded = CheckGround();
        ApplyGravity();
        if (isGrounded)
        {
            readyToJump = true;
        }
        if (CanJump())
        {
            readyToJump = false;
            isGrounded = false;
            Jump();
            //Invoke(nameof(ResetJump), playerStats.JumpCooldown);
        }
    }

    private void ApplyGravity()
    {
        if (isGrounded == false)
        {
            yMovement += playerStats.Gravity;
        }
    }

    private bool CheckGround()
    {
        return Physics.Raycast(groundCheckTransform.position, Vector3.down, groundCheckDistance, whatIsGround);
    }
    private void ApplyMovement()
    {
        Vector3 move;
        move = horizontalMoveVector;
        move.y = yMovement;
        characterController.Move(move * Time.fixedDeltaTime);
    }

    private bool CanJump()
    {
        return readyToJump && isGrounded && playerInput.IsJumpPressed;
    }

    private void Jump()
    {
        yMovement = playerStats.JumpForce;
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
