using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        UnityEngine.Vector3 viewDir = player.position - new UnityEngine.Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        UnityEngine.Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        if(inputDir != UnityEngine.Vector3.zero)
        {
            playerObj.forward = UnityEngine.Vector3.Slerp(playerObj.forward, inputDir, rotationSpeed * Time.deltaTime);
        }
        
    
    }

}
