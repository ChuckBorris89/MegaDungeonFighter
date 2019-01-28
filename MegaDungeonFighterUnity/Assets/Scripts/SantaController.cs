using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SantaController : MonoBehaviour
{

    public Animator animator;
    
    private SpriteRenderer spriteRenderer;
    private bool speed = false;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var y = CrossPlatformInputManager.GetAxis("Vertical");
        var x = CrossPlatformInputManager.GetAxis("Horizontal");
        if (x != 0 || y != 0)
        {
            speed = true;
        }
        else
        {
            speed = false;
        }

        if (x < 0) {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }

        transform.Translate(new Vector3(x*0.1f,y*0.1f,0));
        animator.SetBool("speed", speed);
    }
}
