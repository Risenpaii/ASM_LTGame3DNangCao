using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Enemy Health Settings")]
    public int maxHealth = 100; // Máu tối đa của enemy
    private int currentHealth;
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>(); 
       // Đặt máu hiện tại bằng máu tối đa
       currentHealth = maxHealth;
    }

    void Update()
    {
        // Kiểm tra nếu máu đã hết
        if (currentHealth <= 0)
        {
            enemy.DestroyObject();
            Die();
        }
    }

    // Gọi khi kẻ địch nhận sát thương
    public void TakeDamage(int damage)
    {
        // Giảm máu hiện tại
        currentHealth -= damage;

        // In ra thông báo lượng máu còn lại (nếu cần)
        Debug.Log($"Enemy Health: {currentHealth}/{maxHealth}");
    }

    private void Die()
    {
        Debug.Log("Enemy Died!");
        // Thực hiện logic khi kẻ địch chết (ví dụ: hủy đối tượng)
        Destroy(gameObject);
    }
}
