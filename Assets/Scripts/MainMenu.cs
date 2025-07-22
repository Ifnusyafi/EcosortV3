using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("LevelList");
    }

    public void Credit()
    {
        SceneManager.LoadSceneAsync("Credit");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game exited.");
    }
}
