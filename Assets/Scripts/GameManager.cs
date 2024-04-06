using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int CurrentScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
    }

    public void addScore(int score)
    {
        CurrentScore += score;
        scoreText.text = "Score: " + CurrentScore;
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
