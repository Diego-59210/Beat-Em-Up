using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private CharacterAnimation playerAnim;

    private Rigidbody playerBody;
    public float walkSpeed = 3f;

    bool facingRight = true;
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
        (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walkSpeed), playerBody.velocity.y, Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-walkSpeed));

        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0 && facingRight)
        {
            FlipCharacter();
        }
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
    void FlipCharacter()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
