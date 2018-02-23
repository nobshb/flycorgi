using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreText : MonoBehaviour {

    Text _ScoreText;

    // Use this for initialization
    void Start () {
        _ScoreText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        _ScoreText.text = "Score: " + GameManager.instance.score + " Best: " + GameManager.instance.highScore;
    }
}
