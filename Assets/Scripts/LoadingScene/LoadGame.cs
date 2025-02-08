using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class LoadGame : MonoBehaviour
{
    public bool AutoLoad;
    public GameObject ProgressObject;
    public Image ProgressBar;

    public GameObject Prompt;

    [Tooltip("The build index of the Game scene. Indexes are found in File > Build Settings.")]  public int GameSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        Prompt.SetActive(false);
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation()
    {
        if(AutoLoad)
        {
            AsyncOperation gameLevel = SceneManager.LoadSceneAsync(GameSceneIndex);

            while (gameLevel.progress < 1)
            {
                ProgressBar.fillAmount = gameLevel.progress;
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            AsyncOperation gameLevel = SceneManager.LoadSceneAsync(GameSceneIndex);
            gameLevel.allowSceneActivation = false;

            while (gameLevel.progress < 1)
            {
                ProgressBar.fillAmount = gameLevel.progress;
                yield return new WaitForEndOfFrame();

                if (gameLevel.progress > 0.89f)
                {
                    Prompt.SetActive(true);
                    ProgressObject.SetActive(false);

                    if (Keyboard.current.anyKey.wasPressedThisFrame || Gamepad.current.aButton.wasPressedThisFrame)
                    {
                        gameLevel.allowSceneActivation = true;
                    }
                }
            }
        }
    }
}
