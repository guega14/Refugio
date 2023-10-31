using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D RB;
    public bool isAlive = true;
    public GameObject GameOverPanel;

    //Pulo
    public GameObject checkGround;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool onGround;
    public float forcaPulo;
    public float veloPlayer;


    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxis("Jump");

        RB.velocity= new Vector2(dirX * veloPlayer, RB.velocity.y);

        onGround = Physics2D.OverlapCircle(checkGround.transform.position, checkRadius, whatIsGround);

        if (jump != 0 && onGround ==true)
        {
            RB.velocity = new Vector2(RB.velocity.x, forcaPulo);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(checkGround.transform.position, checkRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isAlive = false;
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Aviso"))
        {
            collision.gameObject.GetComponent<Aviso>().avisoText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Aviso"))
        {
            collision.gameObject.GetComponent<Aviso>().avisoText.SetActive(false);
        }
    }
}