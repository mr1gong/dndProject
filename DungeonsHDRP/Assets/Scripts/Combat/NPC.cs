/**
 * Author: Jindrich Novak
**/

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class NPC : Character
{
    public Stack<Quest> Quests;
    private Quest _CurrentQuest;

    public void Talk()
    {
        if (_CurrentQuest == null)
        {
            _CurrentQuest = Quests.Pop();
        }
        
    }    
}
