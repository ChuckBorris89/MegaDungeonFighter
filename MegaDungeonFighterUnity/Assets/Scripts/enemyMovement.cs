using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    public float speed = 10f;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {

        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;

        if (Vector2.Distance(Player.position, transform.position) < 1.5f)
        {

            if (Vector2.Distance(Player.position, transform.position) > 0.4f)
            {
                transform.position += (displacement * speed * Time.deltaTime);

            }

            else
            {
                //do whatever the enemy has to do with the player
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           // col.gameObject.SendMessage("ApplyDamage", 10);
        }
        if (col.gameObject.tag == "Environment")
        {
            //Vector3 displacement = transform.position;
            //transform.position += (displacement * speed * Time.deltaTime);
        }


    }

}
