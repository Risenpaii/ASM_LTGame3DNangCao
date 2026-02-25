using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitScene : MonoBehaviour
{
    [SerializeField] private string MainMenuScene;
    [Tooltip("The build index of the Closing scene. Indexes are found in File > Build Settings.")][SerializeField] private int ClosingSceneIndex;
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(MainMenuScene);
    }

    public void GoToClosingScene()
    {
        Debug.Log("Quitting game (Build)");
        Application.Quit();
    }
}
