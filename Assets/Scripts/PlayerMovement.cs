using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody player;
   // public Transform playerMelting;
   // public MeshRenderer meltingMesh;
    public GameObject playerMelting;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    void FixedUpdate()
    {
        player.AddForce(0,0, forwardForce * Time.deltaTime);
        if (Input.GetKey("d"))
        {
            player.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (Input.GetKey("a"))
        {
            player.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        //Melting
        float timeToMelt = 0f;
        if (Time.timeSinceLevelLoad > timeToMelt)
        {
            //make render move down
            Vector3 melted = playerMelting.transform.position;
            melted.y -= 0.0002f;
            playerMelting.transform.position = melted;

            timeToMelt = Time.timeSinceLevelLoad;    
            
        }
    }
}
