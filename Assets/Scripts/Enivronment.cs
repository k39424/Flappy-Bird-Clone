using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enivronment : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float scrollSpeed = -1.5f;
    new private BoxCollider2D collider;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        rigid.velocity = new Vector2(scrollSpeed, 0);
    }
    
    void Update()
    {
        if (GameController.instance.IsGameOver())
        {
            rigid.velocity = Vector2.zero;
        }
    }
}
