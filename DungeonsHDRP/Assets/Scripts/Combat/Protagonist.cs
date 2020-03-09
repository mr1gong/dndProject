using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : Combatant
{
    private bool init = false;
    private static Protagonist playerInstance;

    protected override void Start()
    {
        playerInstance = this;
        Canvas.GetDefaultCanvasMaterial().shader = alwaysOnTop;
        timer = 10000;

        GameObject MiniUiPrefabObject = Instantiate(MiniUIPrefab, gameObject.transform);
        MiniUI = MiniUiPrefabObject.GetComponent<MiniUIController>();

        if (MiniUI != null && UIActionButtons != null)
        {
            MiniUI.LoadUIActions(UIActionButtons);
        }

        _IsInvincible = false;
        MiniUI.gameObject.SetActive(false);

        VitalsDisplay.GetInstance().SetSpeed(Speed);
        VitalsDisplay.GetInstance().SetArmourClass(ArmourClass);
    }

    public void MakeInvincible(bool input)
    {
        _IsInvincible = input;
    }

    public static Protagonist GetPlayerInstance() 
    {
    if(playerInstance == null) 
        {
            playerInstance = GameObject.FindObjectOfType<Protagonist>();
        }
        return playerInstance;
    }

    public void MakeInvincible()
    {
        _IsInvincible = true;
    }

    protected override void InitiateDeathSequence()
    {
        UIController.GetInstance().SwitchWindow(UIController.WindowNameResource.DeathSequence);
        //_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        PlayerMovement.MovementEnabled = false;
    }

    protected override void Update()
    {
        base.Update();
        //VitalsDisplay.HitPoints = this.HitPoints;
        //if (!init) { VitalsDisplay.GetInstance().SetDefaultHP(this.HitPoints,true); init = true; }
    }
    public override void ReceiveDamange(int damageSustained)
    {
        base.ReceiveDamange(damageSustained);
        VitalsDisplay.GetInstance().SetHitPoints(this.HitPoints*100/this.HitPoitMaximum);
    }

    
}