using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[Author("Makovec","preAlpha-V0.2")]
public class MiniUIController : MonoBehaviour
{
    public GameObject buttonPrefab;

    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
        Debug.Log(canvas);
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
            GameObject buttonPrefabObject = Instantiate(buttonPrefab);
            buttonPrefabObject.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            Button button = buttonPrefabObject.GetComponent<Button>();
            RawImage rawImage = buttonPrefabObject.gameObject.GetComponentInChildren<RawImage>(true);

            button.onClick.AddListener(delegate() { miniUIAction.Event.Invoke(); });
            rawImage.texture = miniUIAction.TextureImage;

            buttonPrefabObject.transform.SetParent(transform);
        }
    }

}
