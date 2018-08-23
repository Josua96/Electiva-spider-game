using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapCube : MonoBehaviour {

    public GameObject cube;

	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            Destroy(cube);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
