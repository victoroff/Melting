using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public List<GameObject> meshes = new List<GameObject>();
    public PlayerMovement movement;
    public int hits = 3;
    float cooldown = 1f;
    float hitTime;
    GameManager gameManager;
    GameObject activeMesh;
    //melting mesh 
    public GameObject playerMelting;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        hitTime = Time.time;

        if (hits > meshes.Count)
        {
            Debug.Log("mesh count doesn't match the hit count.");
        }
        else
        {
            DecideChildMesh();
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (Time.time - hitTime < cooldown)
                return;

            hitTime = Time.time;
            --hits;

            if (hits <= 0)
            {
                hits = 0;
                EndGame();
            }
            else
            {
                Destroy(collisionInfo.gameObject);
                DecideChildMesh();
            }
        }
        if (collisionInfo.collider.tag == "Snowflake")
        {
            //todo
            // parent game object 
            var playedDefY = movement.gameObject.transform.position.y;

            Vector3 reMelt = playerMelting.transform.position;
            reMelt.y += 0.0001f;

            //cannot let ice cube float 
            if (reMelt.y <= playedDefY)
            {
                playerMelting.transform.position = reMelt;

            }
            
        }
    }

    void DecideChildMesh()
    {
        if ((hits <= meshes.Count) && (hits > 0))
        {
            if (activeMesh != null)
                Destroy(activeMesh);

            Debug.Log("hits: " + hits);
            // change mesh with cracked ice mesh
            activeMesh = GameObject.Instantiate(meshes[hits - 1], transform.position, transform.rotation, transform);
        }
    }

    void EndGame()
    {
        movement.enabled = false;
        gameManager?.EndGame();
    }
}
