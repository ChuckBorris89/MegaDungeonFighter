using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class enemyMovement : MonoBehaviour
{

    public float speed = 1f;
    private GameObject Player;
    public int health = 10;

    private bool isUpGoing = false;
    public int maxSamples;
    private int sample = 0;
    public float rndMove = 0;
    private SpriteRenderer playerSR;
    private SpriteRenderer spriteRenderer;
    private bool isHitting = false;
    private bool isKicking = false;
    private int hitSample = 0;
    private int kickSample = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        playerSR = Player.GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("btn_hit"))
        {
            isHitting = true;
        }
        else if (CrossPlatformInputManager.GetButtonDown("btn_kick"))
        {
            isKicking = true;
        }
        else if (CrossPlatformInputManager.GetButtonUp("btn_hit"))
        {
            isHitting = false;
        }
        else if (CrossPlatformInputManager.GetButtonUp("btn_kick"))
        {
            isKicking = false;
        }

        Vector3 displacement = Player.transform.position - transform.position;
        displacement = displacement.normalized;

        if (Vector2.Distance(Player.transform.position, transform.position) < 1.5f)
        {
            if (Vector2.Distance(Player.transform.position, transform.position) > 0.1f)
            {
                transform.position += (displacement * speed * Time.deltaTime);
                if (displacement.x < 0)
                {
                    spriteRenderer.flipX = false;
                }
                else if (displacement.x > 0)
                {
                    spriteRenderer.flipX = true;
                }
            }

            if (Vector2.Distance(Player.transform.position, transform.position) < 0.4f)
            {
                CheckIfPlayerHit();
            }
        }

        if (isUpGoing)
        {
            if (sample == maxSamples)
            {
                isUpGoing = false;
                sample = 0;
            }
            else
            {
                transform.position += (new Vector3(0f,rndMove*0.01f));
                sample++;
            }
        }
        else
        {
            if (sample == maxSamples)
            {
                isUpGoing = true;
                sample = 0;
            }
            else
            {
                transform.position += (new Vector3(0f,-rndMove*0.01f));
                sample++;
            }
        }
    }

    private void checkIfGameOver()
    {
        //Check if food point total is less than or equal to zero.
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void CheckIfPlayerHit()
    {
        if (isHitting)
        {
            hitSample++;
        }

        if (isKicking)
        {
            kickSample++;
        }
        if (isHitting && hitSample == 20)
        {
            if (Player.transform.position.x < transform.position.x && playerSR.flipX == false)
            {
                health -= 3;
                checkIfGameOver();
            }
            else if (Player.transform.position.x > transform.position.x && playerSR.flipX)
            {
                health -= 3;
                checkIfGameOver();
            }

            hitSample = 0;
        }

        if (isKicking && kickSample == 50)
        {
            if (Player.transform.position.x < transform.position.x && playerSR.flipX == false)
            {
                health -= 10;
                checkIfGameOver();
            }
            else if (Player.transform.position.x > transform.position.x && playerSR.flipX)
            {
                health -= 10;
                checkIfGameOver();
            }

            kickSample = 0;
        }

        
    }
    
}
