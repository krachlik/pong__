using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float initialSpeed = 5.0f; // Initial speed of the ball

    private Rigidbody2D rb;
    private Vector2 initialDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitializeBall();
    }

    void InitializeBall()
    {
        // Set the ball's initial direction (randomly left or right)
        initialDirection = (Random.Range(0, 2) == 0) ? Vector2.left : Vector2.right;

        // Apply initial velocity to the ball
        rb.velocity = initialDirection * initialSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Adjust the ball's direction when it collides with something (e.g., paddles or walls)
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Change the ball's direction based on the paddle's position
            float deltaY = transform.position.y - collision.transform.position.y;
            rb.velocity = new Vector2(-rb.velocity.x, deltaY).normalized * initialSpeed;
        }
    }
}
