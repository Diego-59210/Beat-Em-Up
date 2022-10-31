using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestruct : MonoBehaviour
{

    private bool objetoActivo = true;
    private float temporizador = 0f;
    public float segundos = 5f;

    void Update()
    {
        if (objetoActivo)
        {
            if (temporizador >= segundos)
            {
                Destroy(this.gameObject, t: 0);
                objetoActivo = false;
            }
        }temporizador += Time.deltaTime; 
    }
}
