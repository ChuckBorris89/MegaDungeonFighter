﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class SantaController : MonoBehaviour
{

    public Animator animator;
    public Slider healthSlider;
    public Slider xpSlider;
    
    private SpriteRenderer spriteRenderer;
    private bool doesSpeed = false;
    private bool isRunningLeft = false;
    private bool isFighting = false;
    private int health = 100;
    private int healthMax = 100;
    private int hitCounter = 0;
    private int experience = 0;
    private int level = 0;
    private int strength = 10;
    private float speed = 1.0f;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        healthSlider.value = health;
        xpSlider.value = experience;
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
            doesSpeed = true;
        }
        else
        {
            doesSpeed = false;
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
            transform.Translate(new Vector3(x * 0.03f * speed, y * 0.03f * speed, 0));
            animator.SetBool("speed", doesSpeed);
        }
        else
        { 
            animator.SetBool("speed", false);
        }

    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
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
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            health -= 3;
            if (health < 0)
            {
                health = 0;
            }
            healthSlider.value = health;
            CheckIfGameOver();
        }
        else if (col.gameObject.CompareTag("HealthDrink"))
        {
            health += 20;
            if (health > healthMax)
            {
                health = healthMax;
            }
            healthSlider.value = health;
        }
    }

    private void CheckIfGameOver()
    {
        if (health == 0)
        {
            animator.SetBool("die", true); 
        }
    }

    public void GainExperience(int xp)
    {
        experience += xp;
        CheckIfLevelUp();
        xpSlider.value = experience;
    }

    private void CheckIfLevelUp()
    {
        if (experience < 100) return;
        level++;
        LevelUp();
    }

    private void LevelUp()
    {
        experience = 0;
        xpSlider.value = experience;
    }

    public void UpgradeMaxHealth()
    {
        healthMax += 20;
        healthSlider.maxValue += 20;
    }

    public void UpgradeStrength()
    {
        strength += 2;
    }

    public void UpgradeSpeed()
    {
        speed += 0.2f;
    }

    public int GetStrength()
    {
        return strength;
    }
}
