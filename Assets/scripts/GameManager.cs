using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public static GameManager instance;         
    public Text scoreText;                    
    public GameObject gameOvertext;             

    private int score = 0;                      
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    public KeyCode restartKey = KeyCode.R;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Update()
    {


        if (Input.GetKey(restartKey))
        {
            SceneManager.LoadScene("main");
        }
    }

    public void PlayerScored()
    {
        if (gameOver)
            return;
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void PlayerDied()
    {
        gameOvertext.SetActive(true);
        gameOver = true;
    }
}