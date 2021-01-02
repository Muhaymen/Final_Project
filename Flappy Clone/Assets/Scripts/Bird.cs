using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Bird : MonoBehaviour
{
    public GameManager gameManager;
    Animator anim;
    public Sprite birdDied;
    SpriteRenderer sp;
    
    public Score score;
    
    
    Rigidbody2D rb;
    public float speed;

    
    int angle;
    int maxAngle = 20;
    int minAngle = -90;

    bool touchGround;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            // Jump Korbe
            rb.velocity = Vector2.zero;
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        BirdRotation();      
    }

    void BirdRotation()
    {
        if (rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < -1.3f)
        {
            if (angle >= minAngle)
            {
                angle = angle - 3;
            }
        }
        
        if (touchGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            score.scored();
            Debug.Log("Scores"+score);
        }
        else if(collision.CompareTag("Pipe"))
        {
            //game over.
            gameManager.GameOver();
            GameOverBird();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                //game over.
                gameManager.GameOver();
                GameOverBird();
            }
            else
            {
                //game over bird.
                GameOverBird();
            }
        }
        
    }

    public void GameOverBird()
    {
        touchGround = true;
        anim.enabled = false;
        sp.sprite = birdDied;
        transform.rotation = Quaternion.Euler(0, 0, -90f);
    }
}
