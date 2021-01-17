using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacle;

    public float maxtime;
    float timer;
    public float maxY;
    public float minY;
    float randY;
    void Start()
    {
        //InstantiateObstacles();
    }

    void Update()
    {
        if(GameManager.gameOver == false && GameManager.gameHasStarted == true)
        {
            timer += Time.deltaTime;
            if (timer >= maxtime) //Spawn obstacle
            {
                InstantiateObstacles();
                timer = 0;
            }
        }
        
    }
    public void InstantiateObstacles()
    {
        randY = Random.Range(minY, maxY); //Random position of Y   
        GameObject newObstacle = Instantiate(obstacle); //add reference in newObstacle
        newObstacle.transform.position = new Vector2(transform.position.x, randY); //define position
    }
}
