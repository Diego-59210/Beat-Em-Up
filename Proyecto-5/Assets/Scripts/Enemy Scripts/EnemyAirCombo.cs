using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAirCombo : MonoBehaviour
{
    private Rigidbody enemy;
    public float amount;
 
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ActivateAirTime();
    }
    void FixedUpdate()
    {
        
    }

    void ActivateAirTime()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
           EnemyAir(amount);
        }
        
    }
    void EnemyAir(float amount)
    {
        enemy.velocity += enemy.transform.up * amount;
    }
    
}
