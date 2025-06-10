using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 1f;

    private float timeObstacleSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(GameManager.Instance.isPlaying)
        {
            SpawnLoop();
        }
        
    }

    private void SpawnLoop()
    {
        timeObstacleSpawn += Time.deltaTime;

        if(timeObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();
            timeObstacleSpawn = 0f;
        }
    }

    private void Spawn()
    {
        GameObject obstacleSpawn = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        GameObject spawnedObstacle = Instantiate(obstacleSpawn, transform.position, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }
}
