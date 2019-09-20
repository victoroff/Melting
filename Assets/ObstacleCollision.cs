using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject crackedIceBlock;
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            //init cracked obstacle 
            GameObject.Instantiate(crackedIceBlock,transform.position,transform.rotation);
            //destroy previous
           // Destroy(collisionInfo.gameObject);
        }
    }
}
