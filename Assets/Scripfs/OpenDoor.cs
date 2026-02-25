using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject door1;
    public GameObject door2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenTheDoor()
    {
        door1.SetActive(false);
        door2.SetActive(false);
    }
}
