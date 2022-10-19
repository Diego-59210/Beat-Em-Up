using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private CharacterAnimation playerAnim;

    private Rigidbody playerBody;
    public float walkSpeed = 3f;
    void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<CharacterAnimation>();

    }
    void FixedUpdate()
    {
        DetectMovement();
        AnimatePlayerWalk();
    }
    void DetectMovement()
    {
        playerBody.velocity = new Vector3
            (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed),
            playerBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-walkSpeed));
    }
    void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            playerAnim.Walk(true);
        }
        else
        {
            playerAnim.Walk(false);
        }
    }
}
