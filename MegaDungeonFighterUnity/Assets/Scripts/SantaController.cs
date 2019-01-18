using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SantaController : MonoBehaviour
{

    public Animator animator;
    protected SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var y= CrossPlatformInputManager.GetAxis("Vertical");
        var x = CrossPlatformInputManager.GetAxis("Horizontal");
        if (x < 0) {
            spriteRenderer.flipX;
        }
        transform.Translate(new Vector3(x*0.1f,y*0.1f,0));
        
    }
}
