/**
 * Author: Marek Makovec
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Interactible : MonoBehaviour
{
    

    //Jindrich Code Intrusion Alert
    public Texture2DArray IdleMode;
    public Texture2DArray Interaction;
    private CursorMode CursorMode = CursorMode.Auto;
    private Vector2 CursorOffset = new Vector2(0, 0);
    [HideInInspector]
    public List<MiniUIAction> UIActionButtons = new List<MiniUIAction>();
    public Shader alwaysOnTop;
    protected float timer;
    public string ExamineText = "";
    public GameObject MiniUIPrefab;
    private MiniUIController MiniUI;

    // Start is called before the first frame update
    void Start()
    {
        Canvas.GetDefaultCanvasMaterial().shader = alwaysOnTop;
        timer = 10000;

        GameObject MiniUiPrefabObject = Instantiate(MiniUIPrefab, gameObject.transform);
        MiniUI = MiniUiPrefabObject.GetComponent<MiniUIController>();

        if (MiniUI != null && UIActionButtons != null)
        {
        MiniUI.LoadUIActions(UIActionButtons);
        }

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
