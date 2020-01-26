/**
 * Author: Marek Makovec & Jindrich Novak
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Interactible : MonoBehaviour
{
    //Jindrich Code Intrusion Alert
    //public Texture2DArray IdleMode;
    //public Texture2DArray Interaction;
    public int HitPoints;
    public int HitPoitMaximum;
    public int ArmourClass;
    private CursorMode CursorMode = CursorMode.Auto;
    private Vector2 CursorOffset = new Vector2(0, 0);
    [HideInInspector]
    public List<MiniUIAction> UIActionButtons = new List<MiniUIAction>();
    public Shader alwaysOnTop;
    protected float timer;
    protected bool _IsInvincible;
    public string ExamineText = "";
    public GameObject MiniUIPrefab;
    private MiniUIController MiniUI;

    // Start is called before the first frame update
    [Author("Makovec & Novak", "pre-Alpha")]
    protected virtual void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        UIUpdate();
    }

    private void OnMouseEnter()
    {

    }

    public virtual bool GetItemUsedOn(Item item, out string textResult)
    {
        textResult = "Nothing Happened.";
        return false;
    }

    public string GetExamined()
    {
        return ExamineText;
    }

    //This method is called whenever the character sustains damage
    public virtual void ReceiveDamange(int damageSustained)
    {
        if (!_IsInvincible)
        {
            HitPoints -= damageSustained;
            if (HitPoints <= 0)
            {
                HitPoints = 0;
                _IsInvincible = true;
                InitiateDeathSequence();
            }
        }
    }

    //The following code is run when the character dies
    protected virtual void InitiateDeathSequence()
    {


    }

    protected void UIUpdate()
    {
        if (MiniUI != null) MiniUI.transform.LookAt(Camera.main.transform);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    timer = 0;
                    MiniUI.gameObject.SetActive(true);
                }
            }

            else
            {
                timer += Time.deltaTime;
            }
        }

        //Reserved for future versions.
        //Like in Intel processors?
        //Hrazky would be proud *sob, sob*
        else { }

        if (timer > 2)
        {
            if (MiniUI != null)
                MiniUI.gameObject.SetActive(false);
        }
    }
}
