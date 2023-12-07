using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

public class EntryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI lensText;

    public void SetEntryInfo(string description, LensTypes lensType)
    {
        descriptionText.text = description;
        lensText.text = lensType.EnumToString();
    }

    public void SetEntryInfo(string description)
    {
        descriptionText.text = description;
        lensText.text = "";
    }

    public void SetEntryComplete()
    {
        descriptionText.fontStyle = FontStyles.Strikethrough;
    }
}
