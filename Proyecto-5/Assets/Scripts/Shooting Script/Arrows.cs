using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody Rigidbody;
    void Start()
    {
        Rigidbody.velocity = transform.right * speed;
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        
    }

}
