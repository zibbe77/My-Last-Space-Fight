using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartScenSwitcher : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene(1);
    }
    public void onHelp()
    {
        SceneManager.LoadScene(2);
    }
    public void OnQuitGame()
    {
        Application.Quit();
    }
    public void OnBackToStart()
    {
        SceneManager.LoadScene(0);
    }
}
