using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    private BulletPool bulletPool;
    public GameObject bulletDestroyEffect;
    void Start()
    {
        bulletPool = FindObjectOfType<BulletPool>();

    }
    private void OnCollisionEnter(Collision col)
    {
        Instantiate(bulletDestroyEffect, transform.position, Quaternion.identity);
        if (col.transform.CompareTag("Map"))
        {
            Debug.Log("Hit Map");
            gameObject.SetActive(false);
        }
        if (bulletPool != null)
        {
            bulletPool.ReturnBullet(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}

