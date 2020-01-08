using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    public static int MakeRoll(string input)
    {
        System.Random generator = new System.Random();
        //Parsing the string
        input.Trim();
        input.ToLower();
        int[] rollData;
        try
        {
            rollData = format(input);
        }
        catch (System.Exception)
        {
            Debug.Log($"Invalid Roll Format! [{input}]");
            throw new System.Exception($"Invalid Roll Format! [{input}]");
        }

        //Establishing the roll coefficient (the '2' in 2d4)
        int rollCoefficient = rollData[0];
        //Establishing the die used (the '4' in 2d4)
        int dieType = rollData[1];
        int rollSum = 0;

        for (int iterator = 0; iterator < rollCoefficient; iterator++)
        {
            rollSum += generator.Next(dieType);
        }

        return rollSum;

        //Local method
        int[] format(string formatInput)
        {
            //Spliting the raw input by 'd' (12d2 -> 12, 2)
            string[] unparsedRollData = formatInput.Split('d');
            int[] parsedRollData = new int[2];

            //Loop for converting the two strings separated by 'd' to their numerical values
            for (int iterator = 0; iterator < 2; iterator++)
            {
                parsedRollData[iterator] = int.Parse(unparsedRollData[iterator]);
            }
            return parsedRollData;
        }
    }

    #region Roll Shortcuts
    public static int d20()
    {
        return MakeRoll("1d20");
    }

    public static int d12()
    {
        return MakeRoll("1d12");
    }

    public static int d10()
    {
        return MakeRoll("1d10");
    }

    public static int d8()
    {
        return MakeRoll("1d8");
    }

    public static int d6()
    {
        return MakeRoll("1d6");
    }

    public static int d4()
    {
        return MakeRoll("1d4");
    }

    public static int d2()
    {
        return MakeRoll("1d2");
    }
    #endregion
}
