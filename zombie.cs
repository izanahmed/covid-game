using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    public float moveSpeed = 0.4f;
    public Rigidbody2D rb;
    Vector2 movement;

    void Start()
    {
        movement.x = -1;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Update()
    {
        //nothing rn
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement P1 = collision.collider.GetComponent<PlayerMovement>();
        if ((P1.isProtected))
        { 
            Destroy(gameObject);
            
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    // Update is called once per frame

}
