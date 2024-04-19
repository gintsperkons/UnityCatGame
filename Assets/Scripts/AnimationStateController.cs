using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;
    public Transform Player;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //get horizontal and vertical velocity from rigidbody
        float horizontalVelocity = Math.Abs(Player.GetComponent<Rigidbody>().velocity.x) + Math.Abs(Player.GetComponent<Rigidbody>().velocity.z);
 
        float verticalVelocity = Player.GetComponent<Rigidbody>().velocity.y;



        //set animator parameters
        animator.SetFloat("SpeedH", horizontalVelocity);
        animator.SetFloat("SpeedV", verticalVelocity);
        if(Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        if(!Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }


        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
        }
        if(!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            animator.SetBool("isWalking", false);
        }
    }
}
