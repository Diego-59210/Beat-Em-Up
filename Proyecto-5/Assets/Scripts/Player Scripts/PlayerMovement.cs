using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterAnimation playerAnim;
    private Rigidbody playerBody;

    public float walkSpeed = 3f;
    public float SpeedZ = 1.5f;

    private float RotationY = -90f;
    private float RotationSpeed = 15f;


    // Start is called before the first frame update
    void Awake()
    {
       
        playerBody = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<CharacterAnimation>();

    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
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
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-SpeedZ));
    }
    void RotatePlayer()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(RotationY), 0f);
        }
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(RotationY), 0f);

        }
    }
    void AnimatePlayerWalk()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            playerAnim.Walk(true);
        }
        else
        {
            playerAnim.Walk(false);
        }
    }
}
