using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective
{
    [SerializeField, Tooltip("For displaying in UI"), TextArea(2, 4)]
    public string Description;
    [Space]
    [SerializeField, Tooltip("You can add multiple of the same")]
    public List<MultiObjectiveObject> Objects;
    
    [Header("Time of Day")]
    public bool RequiresSpecificTimeOfDay = false;
    [Space]
    [Header("Position")]
    public bool PositionConstraint = false;
    [Tooltip("Copy position value from a transform (Right click Transform Component > Copy > Position)")]
    public Vector3 Position;
    [Tooltip("How close the camera needs to be to the exact Position")]
    public float MaxDistanceFromPosition = 1;
    [Space] 
    [Header("Lens")] 
    public bool RequiresSpecificLens = false;
    public LensTypes RequiredLens;
}

[System.Serializable]
public class MultiObjectiveObject
{
    public ObjectiveObject Object;
    [Range(1, 10)] public int Amount = 1;
}

/// <summary>
/// Used for identifying objective objects
/// </summary>
public enum ObjectiveObjectNames
{
    Platform,
    SlopedPlatform
}
