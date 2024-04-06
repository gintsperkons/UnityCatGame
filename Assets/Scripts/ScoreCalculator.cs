using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody rigidbody;
    private float currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
        if (rigidbody != null)
        {
            bool isSleeping = rigidbody.IsSleeping();

            if (isSleeping && currentScore > 0)
            {
                gameManager.addScore((int)currentScore);
                currentScore = 0;
            }
            else
            {
                currentScore += rigidbody.velocity.magnitude;
            }
        }
    }



}
