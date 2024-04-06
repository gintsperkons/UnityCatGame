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
        float horizontalVelocity = Player.GetComponent<Rigidbody>().velocity.magnitude;
        float verticalVelocity = Player.GetComponent<Rigidbody>().velocity.y;



        Debug.Log("Horizontal Velocity: " + horizontalVelocity);
        Debug.Log("Vertical Velocity: " + verticalVelocity);

        //set animator parameters
        animator.SetFloat("SpeedH", horizontalVelocity);
        animator.SetFloat("SpeedV", verticalVelocity);


        if(Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
        }
        if(!Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }
    }
}
