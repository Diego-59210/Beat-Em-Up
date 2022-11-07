using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ConditionArea3D : MonoBehaviour
{
    [SerializeField] bool useTag;
    [SerializeField] string tagID;
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    [SerializeField] UnityEvent onTriggerStay;

    // Cuando un objeto con collider 3D entre
    private void OnTriggerEnter(Collider other)
    {
        CheckTagAndDo(onTriggerEnter, other);
    }

    // Cuando un objecto con collider 3D salga
    private void OnTriggerExit(Collider other)
    {
        CheckTagAndDo(onTriggerExit, other);
    }
    // Cuando un objeto con collider 3D se mantenga adentro
    private void OnTriggerStay(Collider other)
    {
        CheckTagAndDo(onTriggerStay, other);
    }

    // Esta funcion obtiene el evento enviado y revisa si estaba filtrando por tag
    private void CheckTagAndDo(UnityEvent accion, Collider other)
    {
        if (useTag)
        {
            if(other.tag == tagID)
            {
                accion?.Invoke();
            }
        }
        else
        {
            accion?.Invoke();
        }
    }
}
