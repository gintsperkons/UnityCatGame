using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHUD : MonoBehaviour
{
    [System.Serializable]
    public struct FinalMessages
    {
        public int scoreMinimum;
        public string message;
    }


    
    [SerializeField] public FinalMessages[] finalMessages;


    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject gameOverUI;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI finalMessageText;



    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        gameOverUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameIsPaused = false;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = true;
    }

    public void ToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0,LoadSceneMode.Single);
    }

     public void ToOptions()
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void BackToPause()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void GameOver(int score, Transform restartPoint)
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        gameOverUI.SetActive(true);
        finalScoreText.text = "Final Score: " + score.ToString();
        int currentMinimum = -1;
        for (int i = 0; i < finalMessages.Length; i++)
        {
            if (score >= finalMessages[i].scoreMinimum && finalMessages[i].scoreMinimum > currentMinimum)
            {
                currentMinimum = finalMessages[i].scoreMinimum;
                finalMessageText.text = finalMessages[i].message;
            }
        }


    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    



    public void Start()
    {
        ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (GameIsPaused)
                ResumeGame();
            else
                PauseGame();
    }
}
