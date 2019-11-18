/**
 * <author>Jindrich Novak</author>
 **/

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;
using static UnityEngine.Input;
using UnityEngine;

[Serializable]
public class Branching
{
    [HideInInspector]
    public int DepthLevel;
    [HideInInspector]
    public string NpcLine;
    [HideInInspector]
    public string PlayerLine;
    [HideInInspector]
    public List<Branching> Options;

    [Author("Novak", "Pre-Alpha 1.2")]
    public Branching(int depthLevel = 0, string playerLine = null, string npcLine = null)
    {
        DepthLevel = depthLevel;
        NpcLine = npcLine;
        PlayerLine = playerLine;
        Options = new List<Branching>();
    }

    [Author("Novak", "Pre-Alpha 1.2")]
    //Needful for the XmlSerializer
    public Branching()
    {
        DepthLevel = 1;
        NpcLine = null;
        PlayerLine = null;
        Options = new List<Branching>();
    }

    [Author("Novak", "Pre-Alpha 1.2")]
    public void AddDialogueOption(Branching inputBranching)
    {
        Options.Add(inputBranching);
    }

    //The method takes in a Text object as an arguement. The Text object reference is used in the overarching class Quest to determine where the conversation strings are to be displayed in Unity. It is a measure which had to be taken to prevent Text from being Branching-class field due to the inability of Unity objects to be serialised

    [Author("Novak", "Pre-Alpha 1.2")]
    public void SaveDialogue(string dialogueName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Branching));
        TextWriter writer = new StreamWriter(dialogueName);
        serializer.Serialize(writer, this);
        writer.Close();
    }

    [Author("Novak", "Pre-Alpha 1.2")]
    public static Branching LoadDialogue(string dialogueName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Branching));
        FileStream fileStream = new FileStream(dialogueName, FileMode.OpenOrCreate);
        Branching toReturn = (Branching)serializer.Deserialize(fileStream);
        fileStream.Close();
        return toReturn;
    }
}

#region Temporary
//SwitchLoop:
//                if (Input.GetKeyDown(KeyCode.F1))
//                switch (true)
//                {
//                    case Input.GetKeyDown(KeyCode.F1):
//                        routeIndex = 1;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F2):
//                        routeIndex = 2;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F3):
//                        routeIndex = 3;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F4):
//                        routeIndex = 4;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F5):
//                        routeIndex = 5;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F6):
//                        routeIndex = 6;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F7):
//                        routeIndex = 7;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F8):
//                        routeIndex = 8;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F9):
//                        routeIndex = 9;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F10):
//                        routeIndex = 10;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F11):
//                        routeIndex = 11;
//                        break;

//                    case Input.GetKeyDown(KeyCode.F12):
//                        routeIndex = 12;
//                        break;

//                    default:
//                        goto SwitchLoop;
//                }


//private void InitialiseBranching(string importPath)
//{
//    Branching temporary = LoadDialogue(importPath);
//    DepthLevel = temporary.DepthLevel;
//    NpcLine = temporary.NpcLine;
//    PlayerLine = temporary.PlayerLine;
//    Options = temporary.Options;
//}
#endregion
