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
        lensText.text = EnumToString(lensType);
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

    private static string EnumToString(Enum @enum)
    {
        return InsertSpaces(@enum.ToString());
    }
    private static string InsertSpaces(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        StringBuilder result = new StringBuilder();
        result.Append(input[0]); // Add the first character as is

        for (int i = 1; i < input.Length; i++)
        {
            char currentChar = input[i];

            // Add a space before capital letters (except for the first letter)
            if (char.IsUpper(currentChar) && i > 1)
            {
                result.Append(' ');
            }
            // Add a space before any amount of digits
            else if (char.IsDigit(currentChar) && !char.IsDigit(input[i - 1]))
            {
                result.Append(' ');
            }

            result.Append(currentChar);
        }

        return result.ToString();
    }
}
