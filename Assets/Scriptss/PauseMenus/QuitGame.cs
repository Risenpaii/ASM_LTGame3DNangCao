using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public GameObject QuitCanvas;
    public GameObject SelectedButton;
    public GameObject DefaultButton;

    public void ShowQuitCanvas()
    {
        QuitCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(SelectedButton);
    }

    public void HideQuitCanvas()
    {
        QuitCanvas.SetActive(false);
        EventSystem.current.SetSelectedGameObject(DefaultButton);
    }

    public void QuitTheGame()
    {
        SceneManager.LoadSceneAsync("ClosingScene");
    }
}
