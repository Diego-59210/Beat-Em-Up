using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraShakeScript : MonoBehaviour
{
    Animator animacion;

    void Start()
    {
        animacion = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            animacion.SetTrigger("golpe");
    }
}
