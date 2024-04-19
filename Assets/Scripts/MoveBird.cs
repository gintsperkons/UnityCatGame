using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveBird : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;

    enum State
    {
        A,
        B,
        C
    }

    private State stateTo = State.B;
    private State stateFrom = State.A;
public float speed = 0.01f; // Adjust this value to your needs
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void FixedUpdate()
    {
        if (stateTo == State.A)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed);
            if (Vector3.Distance(transform.position, pointA.position) < 0.001f)
            {
                stateTo = State.B;
                stateFrom = State.A;
            }
        }
        else if (stateTo == State.B)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed);
            if (Vector3.Distance(transform.position, pointB.position) < 0.001f)
            {
                if (stateFrom == State.A)
                {
                    stateTo = State.C;
                    stateFrom = State.B;
                }
                if (stateFrom == State.C)
                {
                    stateTo = State.A;
                    stateFrom = State.B;
                }
            }
            
        }
        else if (stateTo == State.C)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointC.position, speed);
            if (Vector3.Distance(transform.position, pointC.position) < 0.001f)
            {
                stateTo = State.B;
                stateFrom = State.C;
            }
        }




    }
}
