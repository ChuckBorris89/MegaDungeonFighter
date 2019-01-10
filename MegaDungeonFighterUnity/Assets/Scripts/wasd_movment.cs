using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wasd_movment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float panSpeed = 20f;
   
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }


        transform.position = pos;
    }
}
