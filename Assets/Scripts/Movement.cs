using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D cube;
    public float jumpPower;
    public float moveSpeed;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;
    public KeyCode Stop;

    private int extraJumps;
    public int extraJumpsValue;

    public Transform head;
    public LayerMask whatIsFeet;
    public Transform groundCheckPoint;
    public float feetRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public GameOverScreen GameOverScreen;
    public bool death;
    public LayerMask whatIsPlayer;


    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        cube = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, feetRadius, whatIsGround);
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

        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(Jump) && extraJumps > 0)
        {
            extraJumps--;
            cube.velocity = new Vector2(cube.velocity.x, jumpPower);

            //Debug.Log("1");

        } else if (Input.GetKeyDown(Jump) && extraJumps == 0 && isGrounded == true)
        {
            cube.velocity = new Vector2(cube.velocity.x, jumpPower);

            //Debug.Log("2");

        } else if (Input.GetKey(Stop))
        {
            cube.velocity = new Vector2(cube.velocity.x/2, cube.velocity.y - jumpPower/50);
        }
    }
    /*
    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, feetRadius, whatIsGround);
    }*/

    public void Die()
    {

        GameOverScreen.Setup();
        //SceneManager.LoadScene(0);

        //cube.position = new Vector2(0, 0);
    }

}
