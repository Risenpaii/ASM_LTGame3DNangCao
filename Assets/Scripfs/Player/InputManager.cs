using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerAction player;
    public PlayerAction.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;
    void Awake()
    {
        player = new PlayerAction();
        onFoot = player.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        onFoot.Jump.performed += ctx  => motor.Jump();
        onFoot.Crouch.performed += ctx  => motor.Crounch();
        onFoot.Sprint.performed += ctx  => motor.Sprint();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
