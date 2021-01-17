using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //reload scence


public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool gameHasStarted;
    public GameObject ScoreText;
    public GameObject GetReadyImg;
    public GameObject menuBtn; 
    public GameObject GameOverUI;
    public static Vector2 bottomLeft;

    private void Awake() //write awake and the whole func will appear
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }
    void Start()
    {
        gameOver = false;
        gameHasStarted = false;
    }

    
    void Update()
    {
        
    }

    public void GameHasStarted()
    {
        gameHasStarted = true;
        ScoreText.SetActive(true);
        GetReadyImg.SetActive(false);
    }

    public void GameOver()
    {
        gameOver = true;
        GameOverUI.SetActive(true);
        ScoreText.SetActive(false);
    }

    public void OkBtnPressed()
    {
        SceneManager.LoadScene(0); 
    }
    public void OnMenuBtnPressed()
    {
        SceneManager.LoadScene(1);
    }

}
