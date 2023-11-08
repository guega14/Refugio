using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public float speed;
    public float jumpForce;
    public float stoppingDistance;
    public float detectionRange;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private bool playerInRange = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, Player.position);

            if (!playerInRange && distanceToPlayer < detectionRange)
            {
                playerInRange = true;
            }

            if (playerInRange && distanceToPlayer > stoppingDistance)
            {
                // Move towards the player
                Vector2 direction = (Player.position - transform.position).normalized;
                rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

                // Check if the enemy is on the ground before jumping
                /*if (IsGrounded())
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }*/
            }
            else
            {
                // Stop moving when the player is not close enough or is within stopping distance
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundMask);
        return hit.collider != null;
    }
}
