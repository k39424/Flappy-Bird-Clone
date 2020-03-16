using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float jumpForce = 200f;
    private bool isDead = false;
    private Animator anim;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) { return; }
    
        if (Input.GetMouseButtonDown(0))
        {
            rigid.velocity = Vector2.zero;

            if (transform.position.y < 7)
            {
                rigid.AddForce(new Vector2(0, jumpForce));
            }

            anim.SetTrigger("Flap");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        rigid.velocity = Vector2.zero;
        anim.SetTrigger("Dead");
        GameController.instance.GameOver();
    }
}
