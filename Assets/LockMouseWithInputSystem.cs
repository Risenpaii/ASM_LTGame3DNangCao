using UnityEngine;
using UnityEngine.InputSystem;

public class LockMouseWithInputSystem : MonoBehaviour
{
    private bool isCursorLocked = false;
    public bool falseMouse;

    void Start()
    {
        // Bắt đầu với con trỏ bị khóa
        LockCursor();
    }

    void Update()
    {
        // Nhấn ESC để thoát khỏi chế độ khóa chuột
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            UnlockCursor();
        }

        // Nhấn phím J để khóa lại chuột
        if (Input.GetKeyDown(KeyCode.J) && falseMouse == false)
        {
            Debug.Log("Lock");
            LockCursor();
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isCursorLocked = true;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isCursorLocked = false;
    }
}