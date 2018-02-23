using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player: MonoBehaviour
{
    public float upForce;
    private bool isDead = false;

    public float moveSpeed = 10f;

    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode leftKey = KeyCode.LeftArrow;

    public KeyCode fireKey = KeyCode.Space;

    public GameObject proj;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetKey(fireKey))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }

            if (Input.GetKey(rightKey))
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(leftKey))
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }
        }

            if (Input.GetMouseButtonDown(0))
        {
            GameObject newProjectileObj = Instantiate(proj);
            newProjectileObj.transform.position = transform.position;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        GameManager.instance.PlayerDied();

        if (other.gameObject.tag == "Bad")
        {
            GameManager.instance.PlayerDied();
        }
    }
}