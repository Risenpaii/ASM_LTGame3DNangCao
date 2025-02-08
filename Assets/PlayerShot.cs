using UnityEngine;

public class AimShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public float bulletSpeed = 20f;
    public Camera playerCamera;
    public float fireRate = 0.1f;    // Thời gian giữa mỗi lần bắn

    private float nextFireTime = 0f;
    public ParticleSystem shootEffect;

    private AudioSource gunSound;
    void Start()
    {
        shootEffect.Stop();
        gunSound = GetComponent<AudioSource>();
        //audioClip = GetComponent<AudioClip>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time >= nextFireTime)
            {
                gunSound.mute = false;
                gunSound.Play();
                shootEffect.Play();
                Shoot();
                nextFireTime = Time.time + fireRate; // Cập nhật thời gian bắn tiếp theo
            }
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            shootEffect.Stop();
            gunSound.mute = true; // Tắt tiếng
        }
    }

    void Shoot()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point; // Điểm va chạm
        }
        else
        {
            targetPoint = ray.GetPoint(100f); // Điểm xa nếu không trúng gì
        }

        // Xác định hướng từ nòng súng đến mục tiêu
        Vector3 direction = (targetPoint - muzzlePoint.position).normalized;

        // Tạo đạn và thiết lập hướng
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.LookRotation(direction));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
    }
}