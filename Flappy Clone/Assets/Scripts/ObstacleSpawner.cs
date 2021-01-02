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
        InstantiateObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver == false)
        {
            timer += Time.deltaTime;
            if (timer >= maxtime)
            {
                InstantiateObstacles();
                timer = 0;
            }
        }
        
        
    }

    void InstantiateObstacles()
    {
        randY = Random.Range(minY, maxY);
        GameObject newObstacle = Instantiate(obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x, randY);
    }
}
