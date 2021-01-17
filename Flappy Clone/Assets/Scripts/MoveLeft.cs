using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWidth;

    float pipeWidth;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))//boxcollider only for ground
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        if (gameObject.CompareTag("Obstacles"))
        {
            pipeWidth = GameObject.FindGameObjectWithTag("Pipe").GetComponent<BoxCollider2D>().size.x; //check child class

        }
    }

    void Update()
    {
        if(GameManager.gameOver == false) // when game over ground will be frozen 
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y); //move ground
        }
        

        if (gameObject.CompareTag("Ground"))
        {
            if (transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(transform.position.x + 2 * groundWidth, transform.position.y);//generate ground
            }
        }
            
        else if (gameObject.CompareTag("Obstacles")) //To avoid game crash
        {
            if(transform.position.x < GameManager.bottomLeft.x - pipeWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}
