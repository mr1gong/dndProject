using System;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;
using static UnityEngine.Input;
using static UnityEngine.Debug;
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

    public Branching(int depthLevel = 0, string playerLine = null, string npcLine = null)
    {
        DepthLevel = depthLevel;
        NpcLine = npcLine;
        PlayerLine = playerLine;
        Options = new List<Branching>();
    }

    //Needful for the XmlSerializer
    public Branching()
    {
        DepthLevel = 1;
        NpcLine = null;
        PlayerLine = null;
        Options = new List<Branching>();
    }

    public void AddDialogueOption(Branching inputBranching)
    {
        Options.Add(inputBranching);
    }

    public void StartDialogue(Text lastLine)
    {
        Log("StartDialogue-Method Initiated");
        Branching brachingReference = this;
        Log("StartDialogue-Method Initiated");
        while (brachingReference.Options.Count > 0)
        {
            lastLine.text = $"NPC: '{brachingReference.NpcLine}'\n";
            Log(brachingReference.NpcLine);
            Log(brachingReference.PlayerLine);

            int iterationIndex = 1;
            foreach (Branching option in brachingReference.Options)
            {
                lastLine.text += ($"({iterationIndex}) '{option.PlayerLine}'");
                iterationIndex++;
            }

            int routeIndex;

        ErrorFlag:

            try
            {
                routeIndex = GetUserInput();
                if (routeIndex == 0) goto ErrorFlag;

                if (routeIndex > brachingReference.Options.Count)
                {
                    Log("Invalid input for conversation branching");
                    throw new Exception();
                }

                routeIndex--;
                brachingReference = brachingReference.Options[routeIndex];
            }

            catch(Exception)
            {
                Log("Invalid or No Input");
                goto ErrorFlag;
            }

        AwaitSpacePress:
            if (GetKeyDown(KeyCode.Space))
            {
                continue;
            }

            goto AwaitSpacePress;
        }
        //Conversation flush
        lastLine.text = $"NPC: '{brachingReference.NpcLine}'\n";
    }

    public void SaveDialogue(string dialogueName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Branching));
        TextWriter writer = new StreamWriter(dialogueName);
        serializer.Serialize(writer, this);
        writer.Close();
    }

    public static Branching LoadDialogue(string dialogueName)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Branching));
        FileStream fileStream = new FileStream(dialogueName, FileMode.Open);
        return (Branching)serializer.Deserialize(fileStream);
    }

    private static int GetUserInput()
    {
        if (!anyKey) return 0;

        if (GetKey(KeyCode.F1)) return 1;
        if (GetKey(KeyCode.F2)) return 2;
        if (GetKey(KeyCode.F3)) return 3;
        if (GetKey(KeyCode.F4)) return 4;
        if (GetKey(KeyCode.F5)) return 5;
        if (GetKey(KeyCode.F6)) return 6;
        if (GetKey(KeyCode.F7)) return 7;
        if (GetKey(KeyCode.F8)) return 8;
        if (GetKey(KeyCode.F9)) return 9;
        if (GetKey(KeyCode.F10)) return 10;
        if (GetKey(KeyCode.F11)) return 11;
        if (GetKey(KeyCode.F12)) return 12;
        throw new Exception("Invalid Input");
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
