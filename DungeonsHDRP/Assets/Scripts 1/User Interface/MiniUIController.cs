using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniUIController : MonoBehaviour
{
    public GameObject buttonPrefab;

    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        if(canvas == null)
        {
            Debug.Log("Canvas Not Found");
        }
    }

    private void Update()
    {
        gameObject.transform.LookAt(Camera.main.gameObject.transform);
    }
    public void LoadUIActions(List<MiniUIAction> miniUIActions)
    {
        foreach (MiniUIAction miniUIAction in miniUIActions)
        {
            GameObject b = Instantiate(buttonPrefab);
            b.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            Button button = b.GetComponent<Button>();
            RawImage rw = b.gameObject.GetComponentInChildren<RawImage>(true);

            button.onClick.AddListener(delegate() { miniUIAction.Event.Invoke(); });
            rw.texture = miniUIAction.TextureImage;

            b.transform.SetParent(canvas.gameObject.transform);
        }
    }

}
