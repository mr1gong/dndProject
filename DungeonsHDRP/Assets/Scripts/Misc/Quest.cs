//Author: Jindrich Novak

#region Implementations
using System.IO;
using UnityEngine;
using UnityEngine.UI;
#endregion

public class Quest : MonoBehaviour
{
    public Text LastLine;
    public TextAsset OpeningDialoguePath;
  //  public TextAsset OngoingDialoguePath;
   // public TextAsset ClosingDialoguePath;

    private Branching _OpeningDialogue;
  //  private Branching _OngoingDialogue;
    //private Branching _ClosingDialogue;

    private Item _Reward;
   // private bool _IsOngoing;
   // private bool _IsFinished;

    [Author("Novak", "Pre-Alpha 1.2")]
    void Start()
    {
        Debug.Log("Init Quest");
        InitialiseBranchings();
        //_IsOngoing = false;
       // _IsFinished = false;
    }

    [Author("Novak", "Pre-Alpha 1.2")]
    public void Talk()
    {        
        /*
            if (_IsFinished)
            {
                Debug.Log("IsFinished");
            DialogueReader.GetInstance().LoadDialogue(_ClosingDialogue);
                
                return;
            }

            if (_IsOngoing)
            {
                Debug.Log("IsOngoing");
            DialogueReader.GetInstance().LoadDialogue(_OngoingDialogue);
            return;
            }
            */
            Debug.Log("IsNormal");
            DialogueReader.GetInstance().LoadDialogue(_OpeningDialogue);
    }

    [Author("Novak", "Pre-Alpha 1.2")]
    private void InitialiseBranchings()
    {
        Debug.Log("Init Quest");
        _OpeningDialogue = Branching.LoadDialogue(OpeningDialoguePath);
        //_OngoingDialogue = Branching.LoadDialogue(OngoingDialoguePath);
       // _ClosingDialogue = Branching.LoadDialogue(ClosingDialoguePath);
    }
}
