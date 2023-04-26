using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    float steerSpeed = 250f;
    float moveSpeed = 15f;
    float slowSpeed = 3f;
    float boostSpeed = 20f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, moveAmount, 0);
        if (moveAmount > 0 || moveAmount < 0)
        {
            transform.Rotate(0, 0, -steerAmount);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
        if (other.tag == "Repair")
        {
            moveSpeed = 15f;
        }
    }
}
