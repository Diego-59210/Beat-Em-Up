using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    private CharacterAnimation playerAnim;

    private Rigidbody playerBody;
    public float walkSpeed = 3f;
    public float jumpHeigth = 5f;

    bool facingRight = true;
    bool canJump = true;
    void Awake()
    {
        playerBody = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<CharacterAnimation>();

    }
    void FixedUpdate()
    {
        DetectMovement();
        AnimatePlayerWalk();
        Jump();
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
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
         
            playerBody.velocity = new Vector3(0f, jumpHeigth, 0f);
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if()

    }
}
