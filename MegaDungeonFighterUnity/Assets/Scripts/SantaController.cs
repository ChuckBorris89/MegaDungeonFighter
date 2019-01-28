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
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            transform.Translate(new Vector3(x * 0.1f, y * 0.1f, 0));
            animator.SetBool("speed", speed);
        }
        else
        { 
            animator.SetBool("speed", false);
        }

    }
}
