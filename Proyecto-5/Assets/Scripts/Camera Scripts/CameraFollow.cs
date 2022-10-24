using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        this.transform.position = new Vector3(followTarget.position.x, followTarget.position.y ,followTarget.position.z);

    }
}
