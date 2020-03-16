using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePool : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int obstaclePoolSize = 5;
    public float spawnRate = 3f;
    public float obstacleMin = -1f;
    public float obstacleMax = 3.5f;

    private GameObject[] obstacles;
    private int currentObstacle = 0;
    private Vector2 obstaclePoolPos = new Vector2(-15, -25);
    private float spawnXPosition = 10f;
    private float timeSinceLastSpawned;

    void Start()
    {
        timeSinceLastSpawned = 0f; ;

        obstacles = new GameObject[obstaclePoolSize];

        for (int i = 0; i < obstaclePoolSize; i++)
        {
            obstacles[i] = (GameObject)Instantiate(obstaclePrefab, obstaclePoolPos, Quaternion.identity);
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (!GameController.instance.IsGameOver() && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(obstacleMin, obstacleMax);

            obstacles[currentObstacle].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentObstacle++;

            if (currentObstacle >= obstaclePoolSize)
            {
                currentObstacle = 0;
            }
        }
    }
 
}
