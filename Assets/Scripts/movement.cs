using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed;
    public float acceleration;
    public float maxSpeed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // turning
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rb.rotation -= rotation;

        // acceleration
        float moveDirection = Input.GetAxis("Vertical");
        Vector2 forward = transform.up * moveDirection * acceleration;
        rb.AddForce(forward);

        // speed cap
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}