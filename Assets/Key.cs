using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable
{
    // Start is called before the first frame update
    private KeyPad keyPad;
    void Start()
    {
       keyPad = GetComponent<KeyPad>();
    }

    // Update is called once per frame
    void Update()
    {
    

    }
    protected override void Interact()
    {
        Debug.Log("Key");
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Bullet")) // Kiểm tra nếu người chơi nhặt key
        {
            Debug.Log("ds");
            //keyPad.PickUpKey(); // Gọi hàm PickUpKey() để báo rằng key đã được nhặt
            Destroy(gameObject); // Hủy đối tượng key sau khi nhặt
        }
    }
}
