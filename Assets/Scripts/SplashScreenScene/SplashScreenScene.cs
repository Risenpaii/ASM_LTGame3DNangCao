using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreenScene : MonoBehaviour
{
    [SerializeField][Tooltip("Time (in seconds) to either transition to next scene or display the prompt.")] private float CountdownTimer;
    [SerializeField][Tooltip("Toggle Auto Transition, check to set to True.")] private bool AutoTransition;
    [SerializeField] public GameObject PromptObject;
    [Tooltip("The build index of the next scene. Indexes are found in File > Build Settings.")]public int NextSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        PromptObject.SetActive(false);
        StartCoroutine(SceneTransition());
    }

    IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(CountdownTimer);
        if (AutoTransition)
        {
            SceneManager.LoadScene(NextSceneIndex);
        }
        else
        {
            PromptObject.SetActive(true);
        }
    }
}
