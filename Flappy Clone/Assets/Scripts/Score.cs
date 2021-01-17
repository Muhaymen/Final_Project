using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Converting the text

public class Score : MonoBehaviour
{
    int highScore;
    Text scoreText;
    public Text panelScore;
    public Text panelHighScore;
    public GameObject NewImg;
    int score = 0;
    void Start()
    {
        scoreText = GetComponent<Text>();
        panelScore.text = score.ToString();
        highScore = PlayerPrefs.GetInt("HighScore");
        panelHighScore.text = highScore.ToString(); //starting show best score
    }

    
    void Update()
    {
        
    }

    public void Scored()
    {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();

        if(score > highScore)
        {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
            NewImg.SetActive(true);
        }
    }
}
