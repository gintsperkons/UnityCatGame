using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Experimental.GlobalIllumination;

public class GameManager : MonoBehaviour
{
    public GameHUD GameHUDManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public Transform StartPoint;
    public GameObject dLight;
    private int CurrentScore = 0;
    private float CurrentTime = 0;
    private bool continueTimeCount = true;
    private static readonly float gameStartTime = 480;
    private static readonly float maxTime = 540;
    private static readonly float dayLength = 1440;

    private static readonly Vector3 dayColor = new(0.5f, 0.5f, 0.5f);
    private static readonly Vector3 nightColor = new(0.1f, 0.1f, 0.1f);
    private static readonly int dayIntensity = 1;
    private static readonly int nightIntensity = 0;

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
        CurrentTime += 0.25f;
        if (CurrentTime >= maxTime)
        {
            continueTimeCount = false;
            GameHUDManager.GameOver(CurrentScore, StartPoint);
        }
        yield return new WaitForSeconds(0.125f);
        }
    }

    public void addScore(int score)
    {
        CurrentScore += score;
        scoreText.text = "Score: " + CurrentScore;
    }   

    void UpdateSky()
    {
        float time = (CurrentTime+gameStartTime) % dayLength;
        float intensity = Mathf.Lerp(nightIntensity, dayIntensity, Mathf.PingPong(time, dayLength / 2) / (dayLength / 2));
        Color skyColor = Color.Lerp(new Color(nightColor.x, nightColor.y, nightColor.z), new Color(dayColor.x, dayColor.y, dayColor.z), Mathf.PingPong(time, dayLength / 2) / (dayLength / 2));
        UnityEngine.RenderSettings.ambientLight = skyColor;
        UnityEngine.RenderSettings.ambientIntensity = intensity;
        dLight.GetComponent<Light>().intensity = intensity *2;
        dLight.GetComponent<Light>().color = skyColor;
        dLight.transform.rotation = Quaternion.Euler(new Vector3((time / dayLength) * 360 - 90, 170, 0));

    }

    // Update is called once per frame
    void Update()
    {
        UpdateSky();
        int timeRound = (int)(CurrentTime/5)*5;
        timeText.text = (timeRound/60)+8 + ":" + (timeRound%60 < 10 ? "0"+(timeRound%60) : timeRound%60);
    }
}
