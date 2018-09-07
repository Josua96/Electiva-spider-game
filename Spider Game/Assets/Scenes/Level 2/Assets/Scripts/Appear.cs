using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour {

    public float appearsInterval = 5.0f;

    public float appearRange = 0;
    public float spiderVerticalPosition = -0.019f;
    public float appearsControl = 0.0f;

    public GameObject player;
    public GameObject enemy;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > appearsControl + appearsInterval)
        {
            appearsControl = Time.time;


            Instantiate(enemy, new Vector3(Mathf.Abs(player.transform.position.x - appearRange),
                                                                               spiderVerticalPosition,
                                                                               Mathf.Abs(player.transform.position.z - appearRange)),
                                                                               player.transform.rotation);


        }

    }
}
