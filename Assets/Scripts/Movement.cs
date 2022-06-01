using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D cube;
    public float jumpPower;
    public float moveSpeed;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;
    public KeyCode Stop;

    public int jumps;

    public Transform groundCheckPoint;
    public float feetRadius;
    public LayerMask whatIsGround;
    //public bool isGrounded;

    public bool death;
    public LayerMask whatIsPlayer;


    // Start is called before the first frame update
    void Start()
    {
        cube = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, feetRadius, whatIsGround);

        death = Physics2D.OverlapCircle(groundCheckPoint.position, feetRadius, whatIsPlayer);
        if(death == true) { Die(); }

        if (Input.GetKey(Left))
        {
            cube.velocity = new Vector2(-moveSpeed, cube.velocity.y);
        } else if (Input.GetKey(Right))
        {
            cube.velocity = new Vector2(moveSpeed, cube.velocity.y);
        } else
        {
            cube.velocity = new Vector2(0, cube.velocity.y);
        }

        if (Input.GetKey(Jump) && isGrounded())
        {
            jumps = 1;
            cube.velocity = new Vector2(cube.velocity.x, jumpPower);
        } else  if (Input.GetKey(Stop))
        {
            cube.velocity = new Vector2(cube.velocity.x/2, cube.velocity.y - jumpPower/50);
        } else if(Input.GetKey(Jump) && jumps == 1)
        {
            jumps = 0;
            cube.velocity = new Vector2(cube.velocity.x, jumpPower);
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, feetRadius, whatIsGround);
    }

    void Die()
    {

        cube.position = new Vector2(0, 0);
    }

}
