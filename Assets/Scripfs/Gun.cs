using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Interactable
{
    // Start is called before the first frame update
    public GameObject takeGun;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        gameObject.SetActive(false);
        takeGun.SetActive(true);
    }
}
