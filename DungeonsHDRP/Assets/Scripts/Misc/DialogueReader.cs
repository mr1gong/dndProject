//Author: Marek Makovec & Jindrich Novak

#region Implementations
using UnityEngine;
using UnityEngine.UI;
#endregion

public class DialogueReader : UIElement
{
    public Text DisplayTextComponent;
    private static DialogueReader _Instance;
    private Branching _SelectedBranching;

    void Start()
    {
        _Instance = gameObject.GetComponent<DialogueReader>();
    }

    

    [Author("Novak", "Pre-Alpha 1.2")]
    void Update()
    {
        int key = 0 ;
        if (Input.GetKeyDown(KeyCode.F1)) key = 1;
        if (Input.GetKeyDown(KeyCode.F2)) key = 2;
        if (Input.GetKeyDown(KeyCode.F3)) key = 3;
        if (Input.GetKeyDown(KeyCode.F4)) key = 4;
        if (Input.GetKeyDown(KeyCode.F5)) key = 5;
        if (Input.GetKeyDown(KeyCode.F6)) key = 6;
        if (Input.GetKeyDown(KeyCode.F7)) key = 7;
        if (Input.GetKeyDown(KeyCode.F8)) key = 8;
        if (Input.GetKeyDown(KeyCode.F9)) key = 9;
        if (Input.GetKeyDown(KeyCode.F10)) key = 10;
        if (Input.GetKeyDown(KeyCode.F11)) key = 11;
        if (Input.GetKeyDown(KeyCode.F12)) key = 12;

        if(key != 0)
        {
            LoadDialogue(_SelectedBranching.Options[key-1]);
        }

    }

    [Author("Makovec & Novak", "Pre-Alpha 1.2")]
    public void LoadDialogue(Branching branching)
    {
        _SelectedBranching = branching;

        if (_SelectedBranching.DepthLevel == 0) UIController.GetInstance().OpenWindow(UIController.WindowNameResource.Dialogue);
        if (_SelectedBranching.Options == null) UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.Dialogue);

        DisplayTextComponent.text = "NPC: '" + _SelectedBranching.NpcLine + "'\n";
        int iterationIndex = 1;
        foreach (Branching option in _SelectedBranching.Options)
        {
            Debug.Log("Foreach " + _SelectedBranching.Options.Count);
            DisplayTextComponent.text += ($"({iterationIndex}) '{option.PlayerLine}'");
            iterationIndex++;
        }
    }
    
    [Author("Novák", "Pre-Alpha 1.2")]
    //Singleton-guarantee method
    public static DialogueReader GetInstance()
    {
        if (_Instance == null)
        {
            _Instance = FindObjectOfType<DialogueReader>();
        }
        Debug.Log(_Instance);
        return _Instance;
    }

    [Author("Makovec", "Pre-Alpha 1.2")]
    public void ClearDialogue()
    {
        DisplayTextComponent.text = "";
    }
}