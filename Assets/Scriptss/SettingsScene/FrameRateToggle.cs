using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class FrameRateToggle : MonoBehaviour
{
    public Dropdown frameRateDropdown;
    public static int framerateIndex;

    void Awake()
    {
        frameRateDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("FrameRateDropdownIndex");
        Application.targetFrameRate = PlayerPrefs.GetInt("FrameRate");
    }
    
    public void changeFrameRate(int framerateIndex)
    {
        int frameRateValue = int.Parse(frameRateDropdown.options[frameRateDropdown.value].text);

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = frameRateValue;
        PlayerPrefs.SetInt("FrameRate", Application.targetFrameRate);
        PlayerPrefs.SetInt("FrameRateDropdownIndex", framerateIndex);
        PlayerPrefs.Save();
    }
}
