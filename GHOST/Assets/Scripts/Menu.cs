using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Awake()
    {
        // Switch to 640 x 480 full-screen
        Screen.SetResolution(640, 480, false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Room1");
    }

    public void ResolutionOne()
    {
        // Switch to 640 x 480 full-screen
        Screen.SetResolution(640, 480, false);
    }

    public void ResolutionTwo()
    {
        // Switch to 800 x 600 windowed
        Screen.SetResolution(800, 600, false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
