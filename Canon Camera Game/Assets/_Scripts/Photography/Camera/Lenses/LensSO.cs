using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LensSO", menuName = "Scriptable Object/Lens")]
public class LensSO : ScriptableObject
{
    public LensTypes LensType;
    [Range(1, 160)] public float FieldOfView = 60;
    public Vector2 sensorSize;
}

public enum LensTypes
{
    NormalLens,
    SphereLens,
    TelephotoLens,
    WideAngleLens
}
