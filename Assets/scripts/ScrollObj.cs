using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObj : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.velocity = new Vector2(GameManager.instance.scrollSpeed, 0);

        
    }

    void Update()
    {
       /* if (GameManager.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
        }*/
    }
}