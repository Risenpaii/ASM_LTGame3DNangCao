using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VSyncToggle : MonoBehaviour
{
    public CanvasGroup FrameRate;
    Toggle m_Toggle;

    void Awake()
    {
        //Fetch the Toggle GameObject
        m_Toggle = GetComponent<Toggle>();

        PlayerPrefs.GetInt("VSyncOn");

        if (PlayerPrefs.GetInt("VSyncOn") == 1)
        {
            QualitySettings.vSyncCount = 1;
            //FrameRate.gameObject.SetActive(false);
            m_Toggle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
            //FrameRate.gameObject.SetActive(true);
            m_Toggle.GetComponent<Toggle>().isOn = false;
        }
    }


    void Update()
    {
        //Add listener for when the state of the Toggle changes, and output the state
        m_Toggle.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_Toggle);
        });
    }

    void ToggleValueChanged(Toggle change)
    {
        if (m_Toggle.isOn)
        {
            //FrameRate.gameObject.SetActive(false);
            QualitySettings.vSyncCount = 1;
            PlayerPrefs.SetInt("VSyncOn", QualitySettings.vSyncCount);
        }
        else
        {
            //FrameRate.gameObject.SetActive(true);
            QualitySettings.vSyncCount = 0;
            PlayerPrefs.SetInt("VSyncOn", QualitySettings.vSyncCount);
        }
    }
}
