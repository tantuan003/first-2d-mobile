﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_player_script : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 10;
    private Vector3 originalScale;
    public Rigidbody2D rb;
    public Animator animator;
    void Start()
    {
        originalScale = transform.localScale;
        animator.SetBool("walking",false);
        animator.SetBool("ide", true);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 direction = new Vector3(horizontal, 0, vertical);

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
        if (direction.x > 0.1f)
        {
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z); 
        }
        else if (direction.x < -0.1f)
        {     
        
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        }
        if(rb.velocity.magnitude == 0)
        {
            animator.SetBool("ide", true);
            animator.SetBool("walking", false);

        }
        else
        {
            animator.SetBool("ide",false);
            animator.SetBool("walking", true);
        }
    }
}
