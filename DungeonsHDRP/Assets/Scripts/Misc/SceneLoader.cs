using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string NextScene;

    /*private IEnumerable LoadScene(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }
    }*/

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("LoadingScreen");

        SceneManager.LoadScene(sceneName);
    }

    private void OnCollisionEnter(Collision collision)
    {
        LoadScene(NextScene);
    }
}
