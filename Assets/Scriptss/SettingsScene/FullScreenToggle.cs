using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class FullScreenToggle : MonoBehaviour
{
    public Dropdown fullScreenDropdown;
    private string FullScreen;

    void Awake()
    {
        fullScreenDropdown.onValueChanged.AddListener(new UnityAction<int>(index =>
            {
                PlayerPrefs.SetInt(FullScreen, fullScreenDropdown.value);
            }
        ));
    }

    void Start()
    {
        fullScreenDropdown.value = PlayerPrefs.GetInt(FullScreen);
    }

    void Update()
    {
        changeFullScreen();
    }

    public void changeFullScreen()
    {
        string windowMode = fullScreenDropdown.options[fullScreenDropdown.value].text;
        windowMode = windowMode.Replace(" ", "");

        //Screen.fullScreenMode = FullScreenMode + windowMode;

        switch (fullScreenDropdown.options[fullScreenDropdown.value].text)
        {
            case "Windowed":
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;
            case "FullScreen":
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
            /*case "Maximized Window":
                Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
                break;
            case "Exclusive FullScreen":
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;*/
        }
    }
}
