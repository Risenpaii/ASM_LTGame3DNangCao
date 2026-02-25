using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public float DelayStartTime = 1.5f;
    public static int difficulty;
    [Tooltip("The build index of the Loading scene. Indexes are found in File > Build Settings.")] public int LoadingSceneIndex;
    [Tooltip("The build index of the Main Menu scene. Indexes are found in File > Build Settings.")] public int MenuSceneIndex;

    public void NewGameEasy()
    {
        difficulty = 0;
        StartCoroutine(DelaySceneLoad(DelayStartTime));
    }
    public void NewGameMedium()
    {
        difficulty = 1;
        StartCoroutine(DelaySceneLoad(DelayStartTime));
    }
    public void NewGameHard()
    {
        difficulty = 2;
        StartCoroutine(DelaySceneLoad(DelayStartTime));
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadSceneAsync(MenuSceneIndex);
    }

    IEnumerator DelaySceneLoad(float DelayStartTime)
    {
        yield return new WaitForSeconds(DelayStartTime);
        SceneManager.LoadSceneAsync(LoadingSceneIndex);
    }
}