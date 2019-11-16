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

    //The method takes in a Text object as an arguement. The Text object reference is used in the overarching class Quest to determine where the conversation strings are to be displayed in Unity. It is a measure which had to be taken to prevent Text from being Branching-class field due to the inability of Unity objects to be serialised
    public async void StartDialogue(Text lastLine)
    {
        //'This' should be the root Branching, thus initially setting branchingReference to the first Branching of the dialogue (depth = 0)
        Branching brachingReference = this;
        //Since 'branchingReference' is being overridden at the end of each loop iteration, the while condition shall become false if and only if the segment of the dialogue currently to be displayed has no further options (i.e. the protagonist has nothing else to say)
        int debugIterations = 0;
        while (brachingReference.Options.Count > 0)
        {
            Debug.Log("Iteration: " + debugIterations);

            //Because 'lastLine' is a reference to a real object in Unity(it's the argument of this method), the text displayed in game should change at this point.

            lastLine.text = $"NPC: '{brachingReference.NpcLine}'\n";
            //iterationIndex is merely used for graphical indexing of options on-screen (i.e. it's the '1, 2, 3, etc' in '(1) Hello (2) Hello there, peasant! (3) Bye, bitch
            int iterationIndex = 1;
            //This foreach simply displays the dialogue options for the player (i.e. what he can say to the NPC)
            foreach (Branching option in brachingReference.Options)
            {
                Debug.Log("Foreach");
                lastLine.text += ($"({iterationIndex}) '{option.PlayerLine}'");
                iterationIndex++;
            }
            Canvas.ForceUpdateCanvases();
            Debug.Log("After foreach");
            //routeIndex is used to track which of the options in the List object of options the player selected
            int routeIndex;
        //Loop
        ErrorFlag:
            Debug.Log("ErrorFlag");
            try
            {
                //GetUserInput is a method which returns an int based on which key the player has pressed. If F1, the method returns F1. If F2, then 2, etc. If the player has not pressed any button (or none of the valid option-selection buttons) it returns 0
                routeIndex = GetUserInput();
                //If the player hasn't pressed a valid button, return to ErrorFlag (and thus wait until he makes a valid choice)
                if (routeIndex == 0) goto ErrorFlag;

                //If the option-index is greater than the number of options available, throw an exception (and from the catch section, return to ErrorFlag)
                if (routeIndex > brachingReference.Options.Count)
                {
                    Log("Invalid input for conversation branching");
                    throw new Exception();
                }

                //routeIndex needs to be decremented because the options in the List object of the Branching object (from which the direction of the Branching-object linked-list is determined) are indexed starting with 0 not 1 (like the selection list displayed to the player)

                routeIndex--;

                //Override branchingReference based on the player's dialogue choice
                brachingReference = brachingReference.Options[routeIndex];
            }

            catch (Exception)
            {
                Log("Invalid or No Input");
                goto ErrorFlag;
            }

        //If the player presses the space bar, the if-condition is true and the loop reiterates (now with a different branchingReference)
        AwaitSpacePress:
            if (GetKeyDown(KeyCode.Space))
            {
                continue;
            }
            //
            goto AwaitSpacePress;
        }

        //Conversation flush (NPC is always one line behind the player)
        lastLine.text = $"NPC: '{brachingReference.NpcLine}'\n";
        Canvas.ForceUpdateCanvases();
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
        FileStream fileStream = new FileStream(dialogueName, FileMode.OpenOrCreate);
        Branching toReturn = (Branching)serializer.Deserialize(fileStream);
        fileStream.Close();
        return toReturn;
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
