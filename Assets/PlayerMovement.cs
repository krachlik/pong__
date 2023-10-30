using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * verticalInput * Time.deltaTime * speed);
    }
}
