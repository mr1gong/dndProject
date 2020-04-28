using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    // Start is called before the first frame update
    Renderer r;
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        r.sharedMaterial.SetVector("Position", Protagonist.GetPlayerInstance().transform.position);
    }
}
