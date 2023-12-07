using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// To display what the current lens is.
/// </summary>
public class LensUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lensName;

    public void UpdateCurrentLensUI(LensTypes lens)
    {
        lensName.text = lens.EnumToString();
    }
}
