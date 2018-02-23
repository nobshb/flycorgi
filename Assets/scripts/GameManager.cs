using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public static GameManager instance = null;         
    public Text scoreText;                    
    public GameObject gameOvertext;             

    public int score = 0;
    public int highScore = 0;

    public bool gameOver = false;
    public float scrollSpeed = -1.5f;

    public KeyCode restartKey = KeyCode.R;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        string fullFilePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "SaveData.txt";
        if (File.Exists(fullFilePath))
        {
            string highScoreString = File.ReadAllText(fullFilePath);
            highScore = int.Parse(highScoreString);
        }
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
    public void EndGame()
    {
        if (score > highScore)
        {
            highScore = score;

            string fullFilePath = Application.dataPath + Path.DirectorySeparatorChar + "SaveData.txt";
            File.WriteAllText(fullFilePath, highScore.ToString());
        }
        SceneManager.LoadScene("GameOverScene");
    }
}