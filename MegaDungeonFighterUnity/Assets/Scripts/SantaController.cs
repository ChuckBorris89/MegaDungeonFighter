using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class SantaController : MonoBehaviour
{

    public Animator animator;
    
    private SpriteRenderer spriteRenderer;
    private bool speed = false;
    private bool isRunningLeft = false;
    private bool isFighting = false;
    public int health = 100;
    public Slider healthSlider;
    private int hitCounter = 0;
    
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        var y = CrossPlatformInputManager.GetAxis("Vertical");
        var x = CrossPlatformInputManager.GetAxis("Horizontal");
        
        if (CrossPlatformInputManager.GetButtonDown("btn_hit"))
        {
            isFighting = true;
            animator.SetBool("hit", true);
        }
        else if (CrossPlatformInputManager.GetButtonDown("btn_kick"))
        {
            isFighting = true;
            animator.SetBool("kick", true);
        }
        else if (CrossPlatformInputManager.GetButtonUp("btn_hit"))
        {
            isFighting = false;
            animator.SetBool("hit", false);
        }
        else if (CrossPlatformInputManager.GetButtonUp("btn_kick"))
        {
            isFighting = false;
            animator.SetBool("kick", false);
        }

        
        
        if (x != 0 || y != 0)
        {
            speed = true;
        }
        else
        {
            speed = false;
        }

        if (x < 0) {
            isRunningLeft = true;
        }
        else if (x > 0)
        {
            isRunningLeft = false;
        }
        
        spriteRenderer.flipX = isRunningLeft;

        if (!isFighting)
        {
            transform.Translate(new Vector3(x * 0.05f, y * 0.05f, 0));
            animator.SetBool("speed", speed);
        }
        else
        { 
            animator.SetBool("speed", false);
        }

    }

    void OnCollisionStay2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Enemy")
        {
            hitCounter++;
            if (hitCounter == 20)
            {
                health -= 1;
                if (health < 0)
                {
                    health = 0;
                }

                healthSlider.value = health;
                CheckIfGameOver();
                hitCounter = 0;
            }
            //col.gameObject.SendMessage("ApplyDamage", 10);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            health -= 1;
            if (health < 0)
            {
                health = 0;
            }
            healthSlider.value = health;
            CheckIfGameOver();
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
        if (health == 0)
        {
            animator.SetBool("die", true); 
        }
    }

}
