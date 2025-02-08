using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject SelectedButton;
    public GameObject DefaultButton;

    public void ShowMainMenuCanvas()
    {
        MenuCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(SelectedButton);
    }

    public void HideMainMenuCanvas()
    {
        MenuCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(DefaultButton);
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
