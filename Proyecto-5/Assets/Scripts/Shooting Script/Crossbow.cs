using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{

    public Transform shootingPoint;

    public GameObject arrowPrefab;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(arrowPrefab, shootingPoint.position, shootingPoint.rotation);
    }
}
