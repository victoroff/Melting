using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject crackedIceBlock;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (crackedIceBlock == null)
        {
            return;
        }

        if (collisionInfo.collider.tag == "Player")
        {
            //init cracked obstacle 
            GameObject.Instantiate(crackedIceBlock, transform.position, transform.rotation);
            
            //destroy whole obstacle
            Destroy(gameObject);
        }
    }
}
