using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public AudioSource s;
    public AudioClip SoundClip;
    public float rotationSpeed;
    public float acceleration;
    public float maxSpeed;
    Health health;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
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

        if (Input.GetKey(KeyCode.W))
        {
            // Play the sound
            if (!s.isPlaying) // Ensure sound is not already playing
            {
                s.Play();
            }
        }
        else
        {
            // Stop the sound if 'W' key is released
            s.Stop();
        }

        // speed cap
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            int damage = 10;
            bool died = health.TakeDamage(damage);
            if (died)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            Destroy(collision.gameObject);
        }
    }
}