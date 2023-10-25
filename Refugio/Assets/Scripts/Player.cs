using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        RB.velocity= new Vector2(dirX * 7f, RB.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            RB.velocity = new Vector2(RB.velocity.x, 7f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Call a method to handle player death
            Die();
        }
    }

    private void Die()
    {
        // You can implement your own logic for player death here
        // For example, you might want to play an animation or respawn the player
        Debug.Log("Player has died");
        // Add your own code for handling player death here
    }
}