using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Player: MonoBehaviour
{
    public float upForce;
    private bool isDead = false;

    public KeyCode fireKey = KeyCode.Space;
    //public KeyCode upKey = KeyCode.W;
    //public KeyCode downKey = KeyCode.S;

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
    }
}