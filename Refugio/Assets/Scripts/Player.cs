using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        RB.velocity= new Vector2(dirX * 7f, RB.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            RB.velocity = new Vector2(RB.velocity.x, 7f);
        }
    }
}