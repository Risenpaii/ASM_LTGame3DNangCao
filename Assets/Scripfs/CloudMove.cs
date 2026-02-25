using UnityEngine;

public class CloudMover : MonoBehaviour
{
    public float moveSpeed = 2f; // Tốc độ di chuyển của mây
    public float destroyTime = 30f; // Hủy mây sau X giây

    void Start()
    {
        Destroy(gameObject, destroyTime); // Xóa mây sau 30 giây
    }

    void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0); // Di chuyển từ trái sang phải
    }
}
