using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnim : MonoBehaviour
{
    private Animator anim;
    
    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        anim.Play("GameOver");   
    }
}
