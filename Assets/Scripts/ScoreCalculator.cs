using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody rigidbody;
    private int objectSettleTime = 5; //s
    private bool isSettling = true;
    private float currentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SettleTime());
        rigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    IEnumerator SettleTime()
    {
        yield return new WaitForSeconds(objectSettleTime);
        isSettling = false;
    }


    void FixedUpdate()
    {
        
        if (rigidbody != null)
        {
            bool isSleeping = rigidbody.IsSleeping();
            if (isSettling)
            {
                return;
            }
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
