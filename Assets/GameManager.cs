using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public Transform paddleLeft;
    public Transform paddleRight;
    public float ballSpeed = 5.0f;

    void Start()
    {
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.right * ballSpeed;
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        paddleLeft.Translate(Vector2.up * verticalInput * Time.deltaTime * 5.0f);

        float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        paddleRight.position = new Vector3(paddleRight.position.x, mouseY, paddleRight.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == ball)
        {
            Vector2 dir = ball.transform.position.x < transform.position.x ? Vector2.right : Vector2.left;
            ball.GetComponent<Rigidbody2D>().velocity = dir * ballSpeed;
        }
    }
}
