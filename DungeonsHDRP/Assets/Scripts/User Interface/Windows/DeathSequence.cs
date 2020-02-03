//Author: Jindrich Novak
#region Implementations
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.Debug;
#endregion

public class DeathSequence : UIElement
{
    #region Fields
    private static DeathSequence _DeathSequenceInstance;

    public AudioSource Dirge;
    public GameObject Player;
    public Text Score;
    public Button Button;

    #region Success Toggles
    public Toggle SuccessToggle0;
    public Toggle SuccessToggle1;
    public Toggle SuccessToggle2;
    #endregion

    #region Failure Toggles
    public Toggle FailToggle0;
    public Toggle FailToggle1;
    public Toggle FailToggle2;
    #endregion

    private Toggle[] _SuccessTogleArray;
    private Toggle[] _FailToggleArray;

    private int _FailIterator;
    private int _SuccessIterator;

    private Rigidbody _Rigidbody;
    private Protagonist _PlayerInstance;
    private bool _GameOver;
    #endregion

    void Start()
    {
        InitiateToggles();
        _FailIterator = 0;
        _SuccessIterator = 0;
        _Rigidbody = Player.GetComponent<Rigidbody>();
        _PlayerInstance = Player.GetComponent<Protagonist>();
        _GameOver = false;
    }

    private void Update()
    {
        if (_GameOver && !Dirge.isPlaying)
        {
            UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.DeathSequence);
            SceneManager.LoadScene("MainMenu");
        }
    }

    //Based on the d20 result, either the number of successes or failures rises up to the maximum of three
    //If there are three successes, the character survives
    //If there are three failures, the game is over
    public void DeathRoll()
    {
        if (_GameOver) return;
        int roll = Roller.d20();
        Score.text = roll.ToString(); 
        Log($"Death-Roll: {roll}");
        if (roll > 10)
        {
            //Roll-Success Zone
            _SuccessTogleArray[_SuccessIterator].isOn = true;
            _SuccessIterator++;
        }
        else
        {
            //Roll-Fail Zone
            _FailToggleArray[_FailIterator].isOn = true;
            _FailIterator++;
        }

        if (_SuccessIterator >= 3)
        {
            //_Rigidbody.constraints = RigidbodyConstraints.None;
            PlayerMovement.MovementEnabled = true;
            _PlayerInstance.MakeInvincible(false);
            UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.DeathSequence);
        }

        if (_FailIterator >= 3)
        {
            //RESET PLAYER LOAD-DATA
            Dirge.Play();
            _GameOver = true;
        }
    }

    //Singleton-guarantee method
    public static DeathSequence GetInstance()
    {
        if (_DeathSequenceInstance == null)
        {
            _DeathSequenceInstance = FindObjectOfType<DeathSequence>();
        }
        return _DeathSequenceInstance;
    }

    private void InitiateToggles()
    {
        _SuccessTogleArray = new Toggle[3];
        _FailToggleArray = new Toggle[3];

        _SuccessTogleArray[0] = SuccessToggle0;
        _SuccessTogleArray[1] = SuccessToggle1;
        _SuccessTogleArray[2] = SuccessToggle2;

        _FailToggleArray[0] = FailToggle0;
        _FailToggleArray[1] = FailToggle1;
        _FailToggleArray[2] = FailToggle2;
    }
}
