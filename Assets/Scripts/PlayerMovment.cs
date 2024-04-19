using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{   
    [Header("Keybinds")]

    public KeyCode jumpKey = KeyCode.Space;

    [Header("Movement Settings")]
    
    public float movementSpeed;
    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMovementMultiplier;
    bool readyToJump;

    [Header("References")]
    public Transform orientation;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool isGrounded;

    float horizontalInput;
    float verticalInput;    
    UnityEngine.Vector3 movementDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }


    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, UnityEngine.Vector3.down, playerHeight * 0.1f + 1f, whatIsGround);
        Debug.DrawRay(transform.position, UnityEngine.Vector3.down * (playerHeight * 0.1f + 0.2f), Color.red);
        GetInput();
        SpeedControl();

        if (isGrounded)
        {
            rb.drag = groundDrag;
        }
        else 
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(jumpKey) && readyToJump && isGrounded)
        {
            Jump();
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }

    }

    private void MovePlayer()
    {
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (isGrounded)
            rb.AddForce(movementDirection.normalized * movementSpeed* 10f, ForceMode.Force);
        else if (!isGrounded)
           rb.AddForce(movementDirection.normalized * movementSpeed * airMovementMultiplier, ForceMode.Force);
    }
    private void SpeedControl()
    {
        UnityEngine.Vector3 flatVelocity = new UnityEngine.Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVelocity.magnitude > movementSpeed)
        {
            UnityEngine.Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
            rb.velocity = new UnityEngine.Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new UnityEngine.Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (readyToJump && isGrounded)
        {
            rb.AddForce(UnityEngine.Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
