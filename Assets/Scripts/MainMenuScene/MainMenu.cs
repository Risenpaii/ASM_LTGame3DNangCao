using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //[Header("Text Game Objects")]
    //public Text CompanyName;
    //public Text VersionNo;

    void Awake()
    {
        //VersionNo.text = "Version: " + Application.version;
        //CompanyName.text = Application.productName + " copyright �" + Application.companyName + ". All rights reserved.";
    }

    public void GoToNewGameScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void GoToSettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }
    public void GoToQuitGameScene()
    {
        SceneManager.LoadScene("QuitScene");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
