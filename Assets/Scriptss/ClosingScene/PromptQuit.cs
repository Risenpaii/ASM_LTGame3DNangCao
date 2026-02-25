using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PromptQuit : MonoBehaviour
{
    public void Update()
    {
        if( Keyboard.current.anyKey.wasPressedThisFrame || Gamepad.current.aButton.wasPressedThisFrame )
        {
            Debug.Log("Closing Game...");
            Application.Quit();
        }
    }
}