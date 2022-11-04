using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ReordenarSpritesSegunZ : MonoBehaviour
{

    SpriteRenderer[] sr;
    int[] ordenOriginal;
    private void Start()
    {
        sr = GetComponentsInChildren<SpriteRenderer>();
        ordenOriginal = new int[sr.Length];
        for (int i = 0; i < sr.Length; i++)
        {
            ordenOriginal[i] = sr[i].sortingOrder;
        }
    }


    private void Update()
    {
        for (int i = 0; i < sr.Length; i++)
        {
            sr[i].sortingOrder = (int) transform.position.z * ordenOriginal[i];
        }
    }
}
