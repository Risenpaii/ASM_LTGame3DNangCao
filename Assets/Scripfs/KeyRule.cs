using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRule : MonoBehaviour
{
    // Start is called before the first frame update
    private KeyPad keyPad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
