using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            col.transform.GetComponent<PlayerHealth>().TakeDamge(10);
        }
        Destroy(gameObject);
    } 
}
