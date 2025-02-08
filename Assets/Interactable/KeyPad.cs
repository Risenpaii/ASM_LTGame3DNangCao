using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable
{
    // Start is called before the first frame update
    private OpenDoor openDoor;
    private Animator anm;
    private bool isOpen;
    public float closeTimer;
    void Start()
    {
        openDoor = GetComponent<OpenDoor>();
        anm = GameObject.Find("Door").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    protected override void Interact()
    {
        Debug.Log("dsad");
        isOpen = !isOpen;
        Debug.Log("Interacted with" + gameObject.name);
        closeTimer = Time.deltaTime;
        //door.SetActive(false);
        //door2.SetActive(false);
        anm.SetBool("isOpen", isOpen);
        if (closeTimer > 2)
        {
            anm.SetBool("isOpen", true);
        }

    }
}



