using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatsSO", menuName = "Scriptable Object/Player Stats")]
public class PlayerStatsSO : ScriptableObject
{
    public float MovementSpeed = 8f;
    public float JumpForce = 5;
    public float MouseSensitivity = 2;

}
