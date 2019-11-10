using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    public Text LastLine;
    public string OpeningDialoguePath;
    public string OngoingDialoguePath;
    public string ClosingDialoguePath;

    private Branching _OpeningDialogue;
    private Branching _OngoingDialogue;
    private Branching _ClosingDialogue;

    private Item _Reward;
    private bool _IsOngoing;
    private bool _IsFinished;

    void Start()
    {
        InitialiseBranchings();
        _IsOngoing = false;
        _IsFinished = false;
    }

    public void Talk()
    {
        if (_IsFinished)
        {
            _ClosingDialogue.StartDialogue(LastLine);
            return;
        }

        if (_IsOngoing)
        {
            _OngoingDialogue.StartDialogue(LastLine);
            return;
        }

        _OpeningDialogue.StartDialogue(LastLine);
    }

    private void InitialiseBranchings()
    {
        _OpeningDialogue = Branching.LoadDialogue(OpeningDialoguePath);
        _OngoingDialogue = Branching.LoadDialogue(OngoingDialoguePath);
        _ClosingDialogue = Branching.LoadDialogue(ClosingDialoguePath);
    }
}
