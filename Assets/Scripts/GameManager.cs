using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public GameHUD GameHUDManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public Transform StartPoint;
    private int CurrentScore = 0;
    private int CurrentTime = 0;
    private bool continueTimeCount = true;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
        StartCoroutine(CountTime());
    }

    public IEnumerator CountTime()
    {   
        while (continueTimeCount)
        {
        CurrentTime += 10;
        if (CurrentTime >= 540)
        {
            continueTimeCount = false;
            GameHUDManager.GameOver(CurrentScore, StartPoint);
        }
        yield return new WaitForSeconds(5f);
        }
    }

    public void addScore(int score)
    {
        CurrentScore += score;
        scoreText.text = "Score: " + CurrentScore;
    }   

    // Update is called once per frame
    void Update()
    {

        timeText.text = (CurrentTime/60)+8 + ":" + (CurrentTime%60 < 10 ? "00" : CurrentTime%60);
    }
}
