using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wepon"))
        {
            Die();
        }
    }

    private void Die()
    {

        rb.bodyType = RigidbodyType2D.Static;
        Debug.Log("This is C#");


    }

}
