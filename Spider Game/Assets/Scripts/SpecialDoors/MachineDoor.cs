using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineDoor : MonoBehaviour {

    public GameObject theDoor;

    void OnTriggerEnter(Collider obj)
    {

        theDoor.GetComponent<Animation>().Play("open");
    }

    void OnTriggerExit(Collider obj)
    {

        theDoor.GetComponent<Animation>().Play("close");
    }
}
