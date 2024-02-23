using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    Rigidbody2D fisicaplayer;
    Vector2 vectormovimiento;
    public float speed;
    public float movex;
    public float jump;
    private bool floor = true;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        fisicaplayer = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movex = Input.GetAxis("Horizontal");
        vectormovimiento = new Vector2(movex * speed, fisicaplayer.velocity.y);
        fisicaplayer.velocity = vectormovimiento;

        if (Input.GetButtonDown("Jump") && floor == true)
        {
            fisicaplayer.AddForce(new Vector2(fisicaplayer.velocity.x, jump));
            floor = false;
        }

        if (movex < 0)
        {
            spriteRenderer.flipX = true;
        }

        else if (movex > 0)
        {
            spriteRenderer.flipX = false;
        }

        animator.SetBool("VelX", vectormovimiento.x != 0);

        if (Input.GetButtonDown("Jump") && floor==false)
        {
            animator.SetBool("Jump", true);
        }

        else if (floor == true) 
        
       {
            animator.SetBool("Jump", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            floor = true;

        }

        if (collision.gameObject.CompareTag("Champi"))
        {
            animator.SetLayerWeight(0, 0f);
            animator.SetLayerWeight(1, 1f);
        }
    }
}
