using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wasd_movment : MonoBehaviour
{

    public float panSpeed = 20f;
    public int health = 100;
    public Slider healthSlider;


    // Start is called before the first frame update
    void Start()
    {
        healthSlider.value = health;
    }
    

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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            healthSlider.value -= 5;
            CheckIfGameOver();
          //  healthSlider.value = health;
            //col.gameObject.SendMessage("ApplyDamage", 10);
        }
        if (col.gameObject.tag == "Environment")
        {
            //Vector3 displacement = transform.position;
            //transform.position += (displacement * speed * Time.deltaTime);
        }
    }

    private void CheckIfGameOver()
    {
        //Check if food point total is less than or equal to zero.
        if (healthSlider.value <= 0)
        {

            //Call the GameOver function of GameManager.
            //GameManager.instance.GameOver();
           
        }
    }


}
