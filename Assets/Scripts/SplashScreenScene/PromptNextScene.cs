using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PromptNextScene : MonoBehaviour
{
    private SplashScreenScene splashScreenScene;

    // Start is called before the first frame update
    void Start()
    {
        splashScreenScene = GetComponentInParent<SplashScreenScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( Keyboard.current.anyKey.wasPressedThisFrame || Gamepad.current.aButton.wasPressedThisFrame )
        {
            Debug.Log("Next Scene...");
            SceneManager.LoadScene(splashScreenScene.NextSceneIndex);
        }
    }
}
