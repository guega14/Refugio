using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public float speed;
    public float stoppingDistance;
    public LayerMask groundMask;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Mathf.Abs(transform.position.x - Player.position.x) <= stoppingDistance)
        {
            // Set Y velocity to 0 to prevent movement in Y axis
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        else
        {
            // Set the X velocity based on the direction of the player
            float x = (Player.position.x > transform.position.x) ? speed : -speed;
            rb.velocity = new Vector2(x, rb.velocity.y);
        }
    }
}