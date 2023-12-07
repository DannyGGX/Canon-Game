using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public static class EnumHelper
{
    public static string EnumToString(this Enum @enum)
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
