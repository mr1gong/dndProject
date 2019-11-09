using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string OpeningDialoguePath;
    public string OngoingDialoguePath;
    public string ClosingDialoguePath;

    private Branching _OpeningDialogue;
    private Branching _OngoingDialogue;
    private Branching _ClosingDialogue;

    private Item _Reward;
    private bool _IsOngoing;

    private void Start()
    {
        InitialiseBranchings();
        _IsOngoing = false;
    }

    private void InitialiseBranchings()
    {
        _OpeningDialogue = Branching.LoadDialogue(OpeningDialoguePath);
        _OngoingDialogue = Branching.LoadDialogue(OngoingDialoguePath);
        _ClosingDialogue = Branching.LoadDialogue(ClosingDialoguePath);
    }
}
