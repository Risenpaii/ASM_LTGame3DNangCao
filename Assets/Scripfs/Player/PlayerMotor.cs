using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMotor : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    public float jumpHeight = 4;
    private bool isGrounded;
    private float gravity = -9.8f;
    public float crouchTimer = 1;

    private bool crouching = false;
    private bool lerpCrounch = false;
    private bool sprinting = false;
    private bool isLoadScene;
    public string sceneText;
    public GameObject activeDoor;
    private float loadSceneTimer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(speed);
        //Debug.Log(controller.height);
        float enemyCount = FindObjectsOfType<Enemy>().Length;
        isGrounded = controller.isGrounded;
        if (enemyCount == 0)
        {
            isLoadScene = true;
            //activeDoor.SetActive(false);
        }
        if (lerpCrounch)
        {
            crouchTimer *= Time.deltaTime;
            float p = crouchTimer / 1;
            p *= p;
            if (crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
            }
            if (p > 1)
            {
                lerpCrounch = false;
                crouchTimer = 0;
            }
        }
    }
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        if (isGrounded && playerVelocity.y < 0f)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }
    public void Crounch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrounch = true;
    }
    public void Sprint()
    {
        sprinting = !sprinting;
        if (sprinting)
        {
            speed = 8;
        }
        else
        {
            speed = 5;
        }
    }
    public void Shoot()
    {

    }
    private void OnTriggerEnter(Collider col)
    {
        loadSceneTimer += Time.deltaTime;
        if (col.CompareTag("NextScene") && isLoadScene)
        {

            SceneManager.LoadScene(sceneText);
            Debug.Log("Touch");

        }
    }
}
