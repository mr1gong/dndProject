using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject _parent;
    public float CamSpeed = 5;
    public float RotSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        _parent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(_parent != null) 
        {
            transform.LookAt(_parent.transform);

            float movf = Input.GetAxis("FWD") * CamSpeed * Time.deltaTime;
            float movs = Input.GetAxis("SDW") * CamSpeed * Time.deltaTime;
            float rot = Input.GetAxis("ROT") * RotSpeed *15* Time.deltaTime;
            _parent.transform.Translate(0,0,movf);
            _parent.transform.Translate(movs, 0, 0);
            _parent.transform.Rotate(0, rot, 0);
        }

        
    }
}
