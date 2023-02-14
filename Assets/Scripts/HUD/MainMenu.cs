using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Player Selection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UserPage()
    {
        SceneManager.LoadScene("Login-Register");
    }
}