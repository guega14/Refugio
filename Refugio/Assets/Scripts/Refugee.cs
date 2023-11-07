using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Refugee : MonoBehaviour
{
    private Rigidbody2D RB;

    //Pulo
    public GameObject checkGround;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool onGround;
    public float forcaPulo;
    public float veloPlayer;
    public int preso = 0;
    public int contagem = 1;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (preso == 1)
        {
            float dirX = Input.GetAxisRaw("Horizontal");
            float jump = Input.GetAxis("Jump");

            RB.velocity = new Vector2(dirX * veloPlayer, RB.velocity.y);

            onGround = Physics2D.OverlapCircle(checkGround.transform.position, checkRadius, whatIsGround);

            if (jump != 0 && onGround == true)
            {
                RB.velocity = new Vector2(RB.velocity.x, forcaPulo);
            }
        }
        else 
        {
            //adicionar animação
        }
    }

    private void OnDrawGizmos()
    {
        //a
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(checkGround.transform.position, checkRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            preso = 1;
            contagem = contagem++;
        }

    }
    private void OnCollisionEnter2D(Collider2D collision)
    {
        //a
        if (collision.gameObject.CompareTag("Hell"))
        {
            contagem = contagem - 1;
        }
    }
}
