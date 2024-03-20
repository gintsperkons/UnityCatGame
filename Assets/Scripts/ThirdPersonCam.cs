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


    private void Update()
    {
        // //rotate orientation
        // UnityEngine.Vector3 viewDir = player.position - new UnityEngine.Vector3(transform.position.x, transform.position.y, transform.position.z);
        // orientation.forward = viewDir.normalized;

    }

}
