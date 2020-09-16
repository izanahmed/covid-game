using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    Vector2 movement;
    public bool slow = false;
    public float horizontalMove = 0f;
    public bool isProtected = false;
    private Vector3 _initialPosition;
    private bool isDestroyed = false;
    private string currentSceneName;
    private int count = 0;

    private void Awake()
    {
        _initialPosition = transform.position;
        
    }

    void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        movement.x = 1;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Slow"))
        {
            slow = true;
            moveSpeed = 1f;
        }
        else if (Input.GetButtonUp("Slow"))
        {
            slow = false;
            moveSpeed = 2f;
        }
        else if (isDestroyed)
        {
            SceneManager.LoadScene(currentSceneName);
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        // controller.Move(horizontalMove, slow);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        zombie Z1 = collision.collider.GetComponent<zombie>();
        if ((Z1 != null) && (!isProtected))
        {
            isDestroyed = true;
            return;
        }

}

    public bool getStatus()
    {
        return isProtected;
    }

    public void setStatus(bool state)
    {
        isProtected = state;
    }

    public int getCount()
    {
        return count;
    }

    public void incrementCount()
    {
        count += 1;
    }

    public void decrementCount()
    {
        count -= 1;
    }
}
