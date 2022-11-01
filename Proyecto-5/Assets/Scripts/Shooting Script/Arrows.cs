using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 5f;
    public Rigidbody Rigidbody;
    public float radius;
    public LayerMask collisionLayer;
    public bool isPlayer;

    void Start()
    {
        Rigidbody.velocity = transform.right * speed;
    }
    void Update()
    {
        DetectArrowCollision();
    }
    void DetectArrowCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        if (hit.Length > 0)
        {
            if (isPlayer)
            {
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage);
            }
            gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
