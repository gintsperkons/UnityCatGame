using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1,LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}