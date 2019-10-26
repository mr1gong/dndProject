using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// DEPRECATED DO NOT USE EVER FUKK OFF no
/// </summary>
public class DepressedCharacter : MonoBehaviour
{
    public int Level;
    public int HitPoints;
    public int ArmourClass;
    public List<Weapon> WeaponList = new List<Weapon>();
    public List<Item> ItemList = new List<Item>();

    private int strength;
    private int dexterity;
    private int constitution;
    private int intelligence;
    private int wisdom;
    private int charisma;

    private int strengthMod;
    private int dexterityMod;
    private int constitutionMod;
    private int intelligenceMod;
    private int wisdomMod;
    private int charismaMod;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Character Initialised");
        LoadCharacter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCharacter()
    {
        string input;
        try
        {
            input = File.ReadAllText("CharacterSave");
        }
        catch(Exception)
        {
            throw new Exception("Failed to Load Player Data!");
        }

        string[] rawData = input.Split(',');
        int[] data = new int[rawData.Length];

        for (int index = 0; index < rawData.Length; index++)
        {
            try
            {
                int item = int.Parse(rawData[index]);
            }
            catch (Exception)
            {
                throw new Exception("Data Corrupted!");
            }
        }

        strength = data[0]; dexterity = data[1]; constitution = data[2]; intelligence = data[3]; wisdom = data[4]; charisma = data[5];
        UpdateMods();
    }

    public void SaveCharacter()
    {
        File.WriteAllText("CharacterSave.txt", getParameters());
        string getParameters()
        {
            string output = null;
            output += strength;
            output += ",";
            output += dexterity;
            output += ",";
            output += constitution;
            output += ",";
            output += intelligence;
            output += ",";
            output += wisdom;
            output += ",";
            output += charisma;
            Debug.Log("Saving: '" + output + "'");
            return output;
        }
    }

    public int StrengthCheck()
    {
        return Roll("1d20") + strengthMod;
    }

    public int DexterityCheck()
    {
        return Roll("1d20") + dexterityMod;
    }

    public int ConstitutionCheck()
    {
        return Roll("1d20") + constitutionMod;
    }

    public int IntelligenceCheck()
    {
        return Roll("1d20") + intelligenceMod;
    }

    public int WisdomCheck()
    {
        return Roll("1d20") + wisdomMod;
    }

    public int CharismaCheck()
    {
        return Roll("1d20") + charismaMod;
    }

    public void StrengthIncrease(int gain)
    {
        strength += gain;
    }

    public void DexterityIncrease(int gain)
    {
        dexterity += gain;
    }

    public void ConstitutionIncrease(int gain)
    {
        constitution += gain;
    }

    public void IntelligenceIncrease(int gain)
    {
        intelligence += gain;
    }

    public void WisdomIncrease(int gain)
    {
        wisdom += gain;
    }

    public void CharismaIncrease(int gain)
    {
        charisma += gain;
    }

    public static int Roll(string input)
    {
        System.Random random = new System.Random();
        input.Trim();
        input.ToLower();
        int[] rollData;
        try
        {
            rollData = format(input);
        }
        catch (Exception)
        {
            return -1;
        }

        int rollCoefficient = rollData[0];
        int dieRoll = random.Next(rollData[1]);

        return rollCoefficient * dieRoll;

        int[] format(string formatInput)
        {
            string[] unparsedRollData = formatInput.Split('d');
            int[] parsedRollData = new int[2];
            for (int i = 0; i < parsedRollData.Length; i++)
            {
                parsedRollData[i] = int.Parse(unparsedRollData[i]);
            }
            return parsedRollData;
        }
    }

    private void UpdateMods()
    {
        strengthMod = getMod(strength);
        dexterityMod = getMod(dexterity);
        constitutionMod = getMod(constitution);
        intelligenceMod = getMod(intelligence);
        wisdomMod = getMod(wisdom);
        charismaMod = getMod(charisma);

        int getMod(int mod)
        {
            int trimmedMod = mod - 10;
            int output = trimmedMod / 2;

            return output;
        }
    }
}
