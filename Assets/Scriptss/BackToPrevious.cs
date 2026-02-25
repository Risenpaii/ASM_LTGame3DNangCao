using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToPrevious : MonoBehaviour
{
    public string PreviousSceneName;

    public void BackToScene()
    {
        SceneManager.LoadSceneAsync(PreviousSceneName);
    }
}
