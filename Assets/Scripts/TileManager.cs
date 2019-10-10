using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private Transform playerTransform;

    private float spawnZ = 17f;

    private float tileLength = 19.07f;
    private int amtTilesOnScreen = 8;

    private float safeZone = 67.0f;
    private List<GameObject> activeTiles; 

    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for (int i = 0; i < amtTilesOnScreen; i++)
        {
            SpawnTile();

        }
        
        // DestroyTile();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amtTilesOnScreen * tileLength))
        {
            SpawnTile();
            DestroyTile();
        }
    }

    private void SpawnTile(int prefabIndex = -1) {
        GameObject go;
        go = Instantiate(tilePrefabs[0] as GameObject);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }
    private void DestroyTile()
    {
        // remove tiles behind the player
        Destroy(activeTiles[0], 2f);
        activeTiles.RemoveAt(0);
    }
}
