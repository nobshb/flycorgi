using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player: MonoBehaviour
{
    public float upForce;
    private bool isDead = false;
    public float moveSpeed;
    public float thrust;
    public GameObject proj;
    private Rigidbody2D rb2d;
    public GameObject gameOverText;

    private bool gameStart;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        gameOverText = GameObject.Find("GameOverText");
        gameOverText.SetActive(false);

    }

    void Update()
    {
        //jumping
        if (Input.GetKeyDown(KeyCode.Space)){
            rb2d.constraints = RigidbodyConstraints2D.None;
            Debug.Log("jump!");
            rb2d.AddForce(transform.up * thrust);
            gameStart = true;
        }

        if (isDead == false && gameStart == true)
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            //if (Input.GetKey(fireKey))
            //{
            //    rb2d.velocity = Vector2.zero;
            //    rb2d.AddForce(new Vector2(0, upForce));
            //}

            /*if (Input.GetKey(rightKey))
            {
                transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(leftKey))
            {
                transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
            }*/
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        //GameManager.instance.PlayerDied();

        if (other.gameObject.tag == "Bad")
        {
            //GameManager.instance.PlayerDied();
            //SceneManager.LoadScene("main");


            gameOverText.SetActive(true);

            Invoke("Restart", 1);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}