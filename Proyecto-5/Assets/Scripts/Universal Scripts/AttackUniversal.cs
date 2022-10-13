using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;

    public bool isPlayer, isEnemy;
    public GameObject hitFXPrefab;
    
    void Update()
    {
        DetectCollision();
    }
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        if(hit.Length > 0)
        {
            if(isPlayer)
            {
                Vector3 hitFXPosition = hit[0].transform.position;
                hitFXPosition.y += 1.3f;
                if (hit[0].transform.forward.x > 0)
                {
                    hitFXPosition.x += 0.3f;
                }
                else if (hit[0].transform.forward.x < 0)
                {
                    hitFXPosition.x -= 0.3f;
                }
                Instantiate(hitFXPrefab, hitFXPosition, Quaternion.identity);
                if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.LEFT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                }
                else
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }

            }
            if(isEnemy)
            {
                
                hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                
            }
            gameObject.SetActive(false);
        }
    }
}
