using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject Journal;
    private List<GameObject> UiList = new List<GameObject>();
    private Dictionary<int, GameObject> Windows = new Dictionary<int, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Initalise();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void Initalise()
    {
        UiList.Add(Journal);

        for (int index = 0; index < UiList.Count; index++)
        {
            Windows.Add(index, UiList[index]);
        }
        Debug.Log("Initialisation Successful!");
    }
    
    private void EnableDisableWindow(int index)
    {
        Windows[index].GetComponent<GameObject>();
        //Inverts the enabled-disabled status
        Windows[index].SetActive(!Windows[index].activeSelf);
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            EnableDisableWindow(0);
        }
    }


}
