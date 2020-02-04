using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingScreenController : MonoBehaviour
{
    public GameObject LoadingScreenReference;
    public Slider ProgressBar;
    //Text displaying the player may proceed to the next level
    public Text NextLevelText;

    private AsyncOperation AsyncOperation;

    void Start()
    {
        NextLevelText.enabled = false;
        ProgressBar.value = 0;
        StartCoroutine(Load());
    }

    private void Update()
    {
        if (ProgressBar.value == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               AsyncOperation.allowSceneActivation = true;
            }
        }
    }

    IEnumerator Load()
    {
        LoadingScreenReference.SetActive(true);
        AsyncOperation = SceneManager.LoadSceneAsync(SceneLoader.NextSceneCache);
        AsyncOperation.allowSceneActivation = false;

        while (AsyncOperation.progress < 0.9f)
        {
            ProgressBar.value = AsyncOperation.progress;
        }

        ProgressBar.value = 1;
        NextLevelText.enabled = true;
        //AsyncOperation.allowSceneActivation = true;

        yield return null;
    }
}
