using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{

    private BoxCollider2D collider;

    void Start()
    {
        collider = GetComponent<BoxCollider2D>();

    }
    
    void Update()
    { 
        if (transform.position.x < -collider.size.x)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        Vector2 vectorOffset = new Vector2(collider.size.x * 2f, 0);
        transform.position = (Vector2)transform.position + vectorOffset;
    }
}
