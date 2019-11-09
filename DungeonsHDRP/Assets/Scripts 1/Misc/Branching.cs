using System;
using System.Collections.Generic;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

[Serializable]
public class Branching
{
    public int DepthLevel;
    public string NpcLine;
    public string PlayerLine;
    public List<Branching> Options;

    private Text _LastLine;

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

    public void StartDialogue()
    {
        Branching brachingReference = this;

        while (brachingReference.Options.Count > 0)
        {
            _LastLine.text = $"NPC: '{brachingReference.NpcLine}'\n";
            Debug.Log("NPC Line");

            int iterationIndex = 1;
            foreach (Branching option in brachingReference.Options)
            {
                _LastLine.text += ($"({iterationIndex}) '{option.PlayerLine}'");
                iterationIndex++;
            }

            int routeIndex;
        ErrorFlag:
            try
            {
            SwitchLoop:
                switch (true)
                {
                    case Input.GetKeyDown(KeyCode.F1):
                        routeIndex = 1;
                        break;
                    case Input.GetKeyDown(KeyCode.F2):
                        routeIndex = 2;
                        break;
                    case Input.GetKeyDown(KeyCode.F3):
                        routeIndex = 3;
                        break;
                    case Input.GetKeyDown(KeyCode.F4):
                        routeIndex = 4;
                        break;
                    case Input.GetKeyDown(KeyCode.F5):
                        routeIndex = 5;
                        break;
                    case Input.GetKeyDown(KeyCode.F6):
                        routeIndex = 6;
                        break;
                    case Input.GetKeyDown(KeyCode.F7):
                        routeIndex = 7;
                        break;
                    case Input.GetKeyDown(KeyCode.F8):
                        routeIndex = 8;
                        break;
                    case Input.GetKeyDown(KeyCode.F9):
                        routeIndex = 9;
                        break;
                    case Input.GetKeyDown(KeyCode.F10):
                        routeIndex = 10;
                        break;
                    case Input.GetKeyDown(KeyCode.F11):
                        routeIndex = 11;
                        break;
                    case Input.GetKeyDown(KeyCode.F12):
                        routeIndex = 12;
                        break;
                    default:
                        goto SwitchLoop;
                }

                if (routeIndex > brachingReference.Options.Count || routeIndex < 1)
                {
                    throw new Exception();
                }

                routeIndex--;
            }
            catch
            {
                Debug.Log("Invalid Input");
                goto ErrorFlag;
            }

            brachingReference = brachingReference.Options[routeIndex];
        }
        //Conversation flush
        WriteLine(brachingReference.NpcLine);
        ReadKey();
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
}
