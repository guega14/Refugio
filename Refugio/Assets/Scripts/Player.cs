using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics.Tracing;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;

    private Rigidbody2D RB;
    public bool isAlive = true;
    public GameObject GameOverPanel;
    public GameObject NextPanel;
    [SerializeField] private Animator animator;

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
    public Sprite dialloFinal;
    public Sprite dialloVazio;
    public Sprite estrelaVazia;
    public Sprite estrelaCheia;
    public Sprite estrelaMetade;
    public Image p1;
    public Image p2;
    public Image p3;
    public Image p4;
    public Image p5;
    public Image star1;
    public Image star2;
    public Image star3;

    //Audio
    public AudioClip fallSound;
    private AudioSource audioSource;

    //CountryName
    public GameObject countryName; // Referência ao GameObject do letreiro do país
    public string nomeDoPais = "Sudão do Sul"; // Defina o nome do país aqui

    public int contagem;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        heart3.sprite = fullHeart;
        heart2.sprite = fullHeart;
        heart1.sprite = fullHeart;

        audioSource = GetComponent<AudioSource>();

        countryName.SetActive(false);
        MostrarPaisPorTempo(2f);
    }

    void MostrarPaisPorTempo(float time)
    {
        // Ative o letreiro do país
        countryName.SetActive(true);

        // Defina o texto para exibir o nome do país
        TextMeshProUGUI textoDoPais = countryName.GetComponent<TextMeshProUGUI>();
        if (textoDoPais != null)
        {
            textoDoPais.text = nomeDoPais;
        }

        // Agende a desativação do letreiro após o tempo especificado
        Invoke("DesativarCountryName", 2f);
    }

    void DesativarCountryName()
    {
        // Desative o letreiro do país após o tempo especificado
        countryName.SetActive(false);
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float jump = Input.GetAxis("Jump");

        RB.velocity = new Vector2(dirX * veloPlayer, RB.velocity.y);

        onGround = Physics2D.OverlapCircle(checkGround.transform.position, checkRadius, whatIsGround);
        Animations();
        if (jump != 0 && onGround == true)
        {
            RB.velocity = new Vector2(RB.velocity.x, forcaPulo);
        }
        Debug.Log(contagem);
        if (contagem == 0)
        {
            p1.sprite = dialloVazio;
            p2.sprite = dialloVazio;
            p3.sprite = dialloVazio;
            p4.sprite = dialloVazio;
            p5.sprite = dialloVazio;
        }
        if (contagem == 1)
        {
            p1.sprite = dialloFinal;
            p2.sprite = dialloVazio;
            p3.sprite = dialloVazio;
            p4.sprite = dialloVazio;
            p5.sprite = dialloVazio;
        }
        if (contagem == 2)
        {
            p1.sprite = dialloFinal;
            p2.sprite = dialloFinal;
            p3.sprite = dialloVazio;
            p4.sprite = dialloVazio;
            p5.sprite = dialloVazio;
        }
        if (contagem == 3)
        {
            p1.sprite = dialloFinal;
            p2.sprite = dialloFinal;
            p3.sprite = dialloFinal;
            p4.sprite = dialloVazio;
            p5.sprite = dialloVazio;
        }
        if (contagem == 4)
        {
            p1.sprite = dialloFinal;
            p2.sprite = dialloFinal;
            p3.sprite = dialloFinal;
            p4.sprite = dialloFinal;
            p5.sprite = dialloVazio;
        }
        if (contagem == 5)
        {
            p1.sprite = dialloFinal;
            p2.sprite = dialloFinal;
            p3.sprite = dialloFinal;
            p4.sprite = dialloFinal;
            p5.sprite = dialloFinal;
        }
    }

    void Animations()
    {
        if (RB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (RB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        float velocidadeX = Mathf.Abs(this.RB.velocity.x);
        if (velocidadeX >= 1)
        {
            this.animator.SetBool("correr", true);
        }
        else
        {
            this.animator.SetBool("correr", false);
        }

        if (onGround == true)
        {
            this.animator.SetBool("pular", false);
        }
        else
        {
            this.animator.SetBool("pular", true);
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
            NextPanel.SetActive(true);
            if (contagem == 5)
            {
                star1.sprite = estrelaCheia;
                star2.sprite = estrelaCheia;
                star3.sprite = estrelaCheia;
            }
            if (contagem == 4)
            {
                star1.sprite = estrelaCheia;
                star2.sprite = estrelaCheia;
                star3.sprite = estrelaVazia;
            }
            if (contagem == 3)
            {
                star1.sprite = estrelaCheia;
                star2.sprite = estrelaMetade;
                star3.sprite = estrelaVazia;
            }
            if (contagem == 2)
            {
                star1.sprite = estrelaCheia;
                star2.sprite = estrelaVazia;
                star3.sprite = estrelaVazia;
            }
            if (contagem == 1)
            {
                star1.sprite = estrelaMetade;
                star2.sprite = estrelaVazia;
                star3.sprite = estrelaVazia;
            }
            if (contagem == 0)
            {
                star1.sprite = estrelaVazia;
                star2.sprite = estrelaVazia;
                star3.sprite = estrelaVazia;
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (fallSound != null && audioSource != null)
            {
                // Reproduz o som de queda
                audioSource.PlayOneShot(fallSound);
            }
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