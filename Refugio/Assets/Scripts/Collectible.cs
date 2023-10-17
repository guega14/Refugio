using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private SpriteRenderer SR;
    private CircleCollider2D Circle;
    public GameObject collected;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Circle = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (GetComponent<Collider>().gameObject.tag == "Player")
        {
            SR.enabled = false;
            Circle.enabled = false;
            collected.SetActive(true);
            Destroy(gameObject, 0.2f);
        }
    }
}
