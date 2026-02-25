using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShowSettings : MonoBehaviour
{
    public GameObject SettingsCanvas;

    public void ShowSettingsCanvas()
    {
        SettingsCanvas.SetActive(true);
        Debug.Log("dsd");
    }

    public void HideSettingsCanvas()
    {
        SettingsCanvas.SetActive(false);
    }
}
