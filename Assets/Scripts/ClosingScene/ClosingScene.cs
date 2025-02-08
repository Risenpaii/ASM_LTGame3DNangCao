using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingScene : MonoBehaviour
{
    [SerializeField] [Tooltip("Time (in seconds) to either close the application or to show the prompt to close.")] private float CountdownTimer;
    [SerializeField] [Tooltip("Toggle Auto Close, check to set to True.")] private bool AutoClose;
    [SerializeField] public GameObject ClosePrompt;
    // Start is called before the first frame update
    void Start()
    {
        ClosePrompt.SetActive(false);
        StartCoroutine(CloseApplication());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CloseApplication()
    {
        yield return new WaitForSeconds(CountdownTimer);
        if(AutoClose)
        {
            Debug.Log("Closing Game...");
            Application.Quit();
        }
        else
        {
            ClosePrompt.SetActive(true);
        }
    }
}
