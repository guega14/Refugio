using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    public float speed;

    [SerializeField] private Animator animator;

    private Rigidbody2D rb;
    private bool playerInRange = false;
    public float checkRadius;
    public LayerMask whatIsPlayer;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        playerInRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);

        

        if (playerInRange)
        {
            Vector2 direction = (Player.position - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        float velocidadeX = Mathf.Abs(this.rb.velocity.x);
        if (velocidadeX >= 1)
        {
            this.animator.SetBool("correrE", true);
        }
        else
        {
            this.animator.SetBool("correrE", false);
        }
        /*if (rb.velocity.x < 0)
        
        {
            spriteRenderer.flipX = true;
        }
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }*/
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, checkRadius); 
    }
}
