using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{

    public Transform shootingPoint;

    public GameObject arrowPrefab;

    private CharacterAnimation anim;

    private bool isShooting;

    private void Awake()
    {
        anim = GetComponent<CharacterAnimation>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            anim.Shooting();
        }
    }
    void ShootArrow()
    {
        if (isShooting)
        {
          Instantiate(arrowPrefab, shootingPoint.position, shootingPoint.rotation);
        }  
    }
    void ShootArrowOn()
    {
        isShooting = true;
        
    }
    void ShootArrowOff()
    {
        isShooting = false;

    }
}
