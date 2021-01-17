using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : MonoBehaviour
{
    public GameManager gameManager;
    public ObstacleSpawner obstacleSpawner;
    Animator anim;
    public Sprite birdDied;//new sprite
    SpriteRenderer sp;
    bool touchGround;
    public Score score;
    Rigidbody2D rb;
    public float speed;
    
    
    int angle;
    int maxAngle = 20;
    int minAngle = -90;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //rigidbody component in rb
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb.gravityScale = 0; // this line always in the last or the gravity will not work
    }

    
    void Update()
    {
        if (Input.GetMouseButton(0) && GameManager.gameOver == false)
        {
            if (GameManager.gameHasStarted == false)
            {
                rb.gravityScale = 0.8f;
                Flap();
                obstacleSpawner.InstantiateObstacles();
                gameManager.GameHasStarted();
            }
            else
            {
                Flap();
            }
        }            
        BirdRotation();        
    }

    void Flap()
    {
        rb.velocity = Vector2.zero; //velocity will be zero in every tap in both angle
        rb.velocity = new Vector2(rb.velocity.x, speed); //Jump korbe.vector2 because its 2d(x,y)
    }

    void BirdRotation()
    {
        if (rb.velocity.y > 0)
        {
            rb.gravityScale = 0.8f;
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = 0.6f;
            if (rb.velocity.y < -1.3f)
            {
                if (angle >= minAngle)
                {
                    angle = angle - 3;
                }
            }
                
        }
        if(touchGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);//rotation on z axis
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            
            score.Scored();
            Debug.Log("Scored");
        }
        else if(collision.CompareTag("Pipe"))
        {
            gameManager.GameOver();//game over
            GameOverBird();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver == false)
            {
                gameManager.GameOver();//game over
                GameOverBird();
            }
            else
            {
                
                GameOverBird();
            }

        }
        
    }

    public void GameOverBird() //animation and bird freeze
    {
        touchGround = true; //game over Bird
        anim.enabled = false;
        sp.sprite = birdDied; //change bird sprite
        
        transform.rotation = Quaternion.Euler(0, 0, -90f);

    }



}
