using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "Scriptable Object/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    public float WalkSpeed = 8f;
    public float SprintSpeed = 14f;
    [Space]
    [Header("Jumping")]
    public float JumpForce = 5;
    public float JumpCooldown = 0.3f;
    public float CoyoteTime = 0.2f;
    public float Gravity = -9;
    [Space]
    public float MouseSensitivity = 2;

}
