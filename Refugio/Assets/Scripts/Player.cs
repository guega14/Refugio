using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    //Vida
    public int health;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        heart3.sprite = fullHeart;
        heart2.sprite = fullHeart;
        heart1.sprite = fullHeart;
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxis("Jump");

        RB.velocity= new Vector2(dirX * veloPlayer, RB.velocity.y);

        onGround = Physics2D.OverlapCircle(checkGround.transform.position, checkRadius, whatIsGround);
        Animations();
        if (jump != 0 && onGround ==true)
        {
            RB.velocity = new Vector2(RB.velocity.x, forcaPulo);
        }
    }
    void Animations()
    {
        if(RB.velocity.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
            }
        if (RB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
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
            health = health - 1;

            if (health == 2)
            {
                heart3.sprite = fullHeart;
                heart2.sprite = fullHeart;
                heart1.sprite = emptyHeart;
            }
            if (health == 1)
            {
                heart3.sprite = fullHeart;
                heart2.sprite = emptyHeart;
                heart1.sprite = emptyHeart;
            }
            if (health == 0)
            {
                heart3.sprite = emptyHeart;
                heart2.sprite = emptyHeart;
                heart1.sprite = emptyHeart;
                isAlive = false;
                Time.timeScale = 0;
                GameOverPanel.SetActive(true);
            }
        }

        if (collision.gameObject.CompareTag("Hell"))
        {
            heart3.sprite = emptyHeart;
            heart2.sprite = emptyHeart;
            heart1.sprite = emptyHeart;
            isAlive = false;
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Heven"))
        {
            SceneManager.LoadScene("Fase2");
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