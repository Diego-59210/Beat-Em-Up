using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemen2D : MonoBehaviour
{
    private Rigidbody playerBody;
    public float walkSpeed = 3f;
    void Awake()
    {
        playerBody = GetComponent<Rigidbody>();

    }
    void FixedUpdate()
    {
        DetectMovement();
    }
    void DetectMovement()
    {
        playerBody.velocity = new Vector3
            (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed),
            playerBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-walkSpeed));
    }
}
