using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysOnTop : MonoBehaviour
{

    public Shader shader;

    private void OnEnable()
    {
        Canvas.GetDefaultCanvasMaterial().shader = shader;
    }
}
