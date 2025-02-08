using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TogglePauseMenu : MonoBehaviour
{
    public GameObject PauseCanvas;
    public GameObject SelectedButton;

    private PlayerControls playerControls;

    void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Player.OpenPauseMenu.performed += OpenPauseMenu;
        playerControls.PauseMenu.ClosePauseMenu.performed += ClosePauseMenu;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Player.OpenPauseMenu.performed -= OpenPauseMenu;
        playerControls.PauseMenu.ClosePauseMenu.performed -= ClosePauseMenu;
    }

    public void OpenPauseMenu(InputAction.CallbackContext obj)
    {
        Time.timeScale = 0f;
        playerControls.Player.Disable();
        playerControls.PauseMenu.Enable();
        PauseCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(SelectedButton);
        Cursor.visible = true;
    }

    public void ClosePauseMenu(InputAction.CallbackContext obj)
    {
        Time.timeScale = 1f;
        playerControls.Player.Enable();
        playerControls.PauseMenu.Disable();
        PauseCanvas.SetActive(false);
        Cursor.visible = false;
    }

}
