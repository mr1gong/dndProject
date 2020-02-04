using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string NextScene;
    //Used to store the name of the next scene once the loading-screen scene is loaded
    public static string NextSceneCache;

    public static void ToLoadingScreen(string sceneName)
    {
        NextSceneCache = sceneName;
        SceneManager.LoadScene("LoadingScreen");
    }

    private void OnCollisionEnter(Collision collision)
    {
        ToLoadingScreen(NextScene);
    }
}
