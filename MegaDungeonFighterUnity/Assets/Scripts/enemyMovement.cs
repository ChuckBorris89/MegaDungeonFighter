using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    private Transform target;
    public float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 pos = transform.position;

        if (pos.x-target.position.x < 5 && pos.x - target.position.x > -5)
        {
            if (pos.y - target.position.y < 5 && pos.y - target.position.y > -5)
            {
                pos.y += speed * Time.deltaTime;
                pos.y -= speed * Time.deltaTime;
                pos.x += speed * Time.deltaTime;
                pos.x -= speed * Time.deltaTime;

            }

        }

       

    }



}
