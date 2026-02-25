using UnityEngine;

public class AimShoot : MonoBehaviour
{
    public Transform muzzlePoint;
    public float bulletSpeed = 20f;
    public Camera playerCamera;
    public float fireRate = 0.1f;
    public ParticleSystem shootEffect;

    private float nextFireTime = 0f;
    private AudioSource gunSound;
    private BulletPool bulletPool;
    private Animator anm;
    private GameObject crossHair;

    void Start()
    {
        anm = GetComponent<Animator>();
        crossHair = GameObject.Find("CrossHair");
        if (shootEffect != null)
            shootEffect.Stop();

        gunSound = GetComponent<AudioSource>();
        bulletPool = FindObjectOfType<BulletPool>();

        if (gunSound == null)
            Debug.LogWarning("Không tìm thấy AudioSource trên " + gameObject.name);

        if (bulletPool == null)
            Debug.LogError("Không tìm thấy BulletPool trong scene!");
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;

            if (shootEffect != null && !shootEffect.isPlaying)
                shootEffect.Play();

            if (gunSound != null && !gunSound.isPlaying)
                gunSound.Play();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            if (shootEffect != null && shootEffect.isPlaying)
                shootEffect.Stop();

            if (gunSound != null && gunSound.isPlaying)
                gunSound.Stop();
        }
        if (Input.GetButtonDown("Fire2")) // Giữ chuột phải
        {
            Debug.Log("Đang giữ chuột phải!");
            anm.SetBool("isScope", true);
            crossHair.SetActive(false);
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            anm.SetBool("isScope", false);
            crossHair.SetActive(true);
        }
    }

    void Shoot()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        Vector3 targetPoint = ray.GetPoint(100f);

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }

        Vector3 direction = (targetPoint - muzzlePoint.position).normalized;

        GameObject bullet = bulletPool.GetBullet();
        bullet.transform.position = muzzlePoint.position;
        bullet.transform.rotation = Quaternion.LookRotation(direction);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }

        // Gửi bullet trở lại pool sau một khoảng thời gian
        StartCoroutine(ReturnBulletToPool(bullet, 3f));
    }
    System.Collections.IEnumerator ReturnBulletToPool(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        bulletPool.ReturnBullet(bullet);
    }
}
