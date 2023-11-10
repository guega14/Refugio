using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public float speed;

    private Rigidbody2D rb;
    private bool playerInRange = false;
    public float checkRadius;
    public LayerMask whatIsPlayer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

        if (playerInRange)
        {
            // Move towards the player
            Vector2 direction = (Player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
        else
        {
            // Stop moving when the player is not close enough or is within stopping distance
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, checkRadius); 
    }
}
