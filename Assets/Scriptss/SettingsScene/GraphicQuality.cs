using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GraphicQuality : MonoBehaviour
{
    public GameObject QualityDropdown;
    public static int qualityIndex;

    void Awake()
    {
        QualityDropdown.GetComponent<Dropdown>().value = PlayerPrefs.GetInt("QualityDropdown");
        PlayerPrefs.GetInt("QualityDropdown");
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("QualityDropdown", qualityIndex);
        PlayerPrefs.Save();
    }
}
