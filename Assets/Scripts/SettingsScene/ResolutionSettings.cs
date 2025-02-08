using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionSettings : MonoBehaviour
{
    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    void Awake()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @" + resolutions[i].refreshRateRatio + "Hz";
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("ResolutionDropdownIndex");
    }

    public void ChangeResolution(int resolutionIndex)
    {
        PlayerPrefs.SetInt("ResolutionDropdownIndex", resolutionIndex);
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRateRatio);
    }
}
