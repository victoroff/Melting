using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowflakeManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject snowFlakePrefab;
    public Transform player;

    // checking if player is moving
    public PlayerMovement movement;

    //time multiplayer for each wave
    public float WaveTime = 200f;

    // time to spond each snowflake
    // managable distance for snowflake spawning
    public float spawnDistance = 1f;

    private float spawnTime = 3f;
    private List<GameObject> activeflakes;

    private void Start()
    {
        // collection to keep last blocks before spawn
        activeflakes = new List<GameObject>();


        // no need to spawn flakes at the beggining
        //SpawnSnowflake(spawnDistance);
        //DestroySnowflakes();
    }

    void Update()
    {
        //TODO : MAKE SNOWFLAKES SPAWN w
        //measure from the current loaded scene not from the begining of the game
        if (Time.timeSinceLevelLoad >= spawnTime)
        {
            SpawnSnowflake(spawnDistance);
            spawnTime = Time.timeSinceLevelLoad + WaveTime;
            DestroySnowflakes();
        }

    }

    private void SpawnSnowflake(float spawnDistance)
    {
        int randIdx = Random.Range(0, spawnPoints.Length + 1);
        for (int i = 0; i < spawnPoints.Length - 1; i++)
        {
            // Debug.Log("randIDx:" + randIdx + "i:" + i);
            if (randIdx != i)
            {
                GameObject snowflake;
                var snowflakePosition = spawnPoints[i].position;
                snowflakePosition.z += player.position.z + spawnDistance;
                snowflake = Instantiate(snowFlakePrefab, snowflakePosition, snowFlakePrefab.transform.rotation);

                activeflakes.Add(snowflake);
            }
        }
    }
    private void DestroySnowflakes()
    {
        // in order to keep the bugs out
        if (activeflakes.Count == 0)
        {
            return;
        }

        for (int i = 0; i < activeflakes.Count; i++)
        {
            // second parameter is for delaying the destroy so the player could pass by
            Destroy(activeflakes[i], 2f);
            activeflakes.RemoveAt(i);
        }
        //passedBlocks = 0;

    }
}
