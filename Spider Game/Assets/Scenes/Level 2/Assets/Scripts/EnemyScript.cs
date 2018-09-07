using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject player;
    public float moveSpeed = 20.0f;
  

    public float moveAmount = 2;

    public float rotationSpeed = 20.0f;

    public float moveControl = 0.0f;
    public float moveInterval = 0.3f;
    
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if ( Time.time > moveControl+ moveInterval)
        {
            moveControl = Time.time;

            // rotate to look at the player
            
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                                 Quaternion.LookRotation(player.transform.position - transform.position),
                                 rotationSpeed * Time.deltaTime);

            //move towards the player
            transform.position += transform.forward * Time.deltaTime * moveSpeed;

        } 

        
	}
}
