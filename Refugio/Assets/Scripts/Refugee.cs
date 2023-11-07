using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Refugee : MonoBehaviour
{
    private Rigidbody2D RB;
    private BoxCollider2D playerCollider, boxCollider;

    public GameObject refugeePos;

    //Pulo
    public GameObject checkGround;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool onGround;
    public float forcaPulo;
    public float veloPlayer = 6;
    public int preso = 0;
    public int contagem = 1;
    public float dist;
    float dirX;
          float jump;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        if (preso == 1)
        {
            playerCollider = GetComponent<BoxCollider2D>();
            boxCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(playerCollider, boxCollider, true);
            transform.position = Vector2.MoveTowards(transform.position, refugeePos.transform.position, veloPlayer);
        }
        else 
        {
            //adicionar animação
            boxCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(playerCollider, boxCollider, false);
            float dirX = Input.GetAxisRaw("Horizontal");
            float jump = Input.GetAxis("Jump");
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            preso = 0;
            contagem = contagem--;
        }

    }
    private void OnCollisionEnter2D(Collider2D collision)
    {
        //a
        if (collision.gameObject.CompareTag("Hell"))
        {
            contagem = contagem--;
        }
    }
}
