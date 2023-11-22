using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Refugee : MonoBehaviour
{
    private Rigidbody2D RB;
    private BoxCollider2D playerCollider, boxCollider;
    [SerializeField] private Animator animator;

    public GameObject refugeePos;

    //Pulo
    public GameObject checkGround;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool onGround;
    public float forcaPulo;
    public float veloPlayer = 6;
    public int preso = 0;
    public float dist;
    public float jump;
    public int contagem;


    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();

    }

    private void FixedUpdate()
    {
        if (preso == 1)
        {
            onGround = Physics2D.OverlapCircle(checkGround.transform.position, checkRadius, whatIsGround);
            float dirXR = Input.GetAxisRaw("Horizontal");
            float jumpR = Input.GetAxis("Jump");
            boxCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(playerCollider, boxCollider, true);

            if (onGround == true)
            {
                float velocidadeX = Mathf.Abs(this.RB.velocity.x);
                if (velocidadeX >= 1)
                {
                    this.animator.SetBool("corree", true);
                    this.animator.SetBool("pulaa", false);
                }
                else
                {
                    this.animator.SetBool("corree", false);
                    this.animator.SetBool("pulaa", false);
                }
            }
            else
            {
                this.animator.SetBool("pulaa", true);
                this.animator.SetBool("corree", false);

            }

            RB.velocity = new Vector2(dirXR * veloPlayer, RB.velocity.y);
            if (jumpR != 0 && onGround == true)
            {
                RB.velocity = new Vector2(RB.velocity.x, forcaPulo);
            }

            transform.position = Vector2.MoveTowards(transform.position, new Vector3(refugeePos.transform.position.x, transform.position.y, 0), veloPlayer * Time.deltaTime);
            if (RB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (RB.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            this.animator.SetBool("pulaa", false);
            this.animator.SetBool("corree", false);
            boxCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(playerCollider, boxCollider, false);
        }

    }


private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(checkGround.transform.position, checkRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            preso = 1;
            Player.instance.contagem++;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            preso = 0;
            Player.instance.contagem--;
        }
        if (collision.gameObject.CompareTag("Hell"))
        {
            preso = 0;
            Player.instance.contagem--;
        }

    }
}
