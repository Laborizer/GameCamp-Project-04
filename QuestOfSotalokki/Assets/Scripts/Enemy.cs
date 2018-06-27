using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject cameraSwitch;

    private bool camerachange;

    void Start () {
        cameraSwitch = GameObject.Find("Cameras");
        camerachange = false;
    }

    private void Update()
    {
        if (camerachange && Input.GetKey(KeyCode.E))
        {
            cameraSwitch.GetComponent<CameraSwitch>().setInBattle(true);
        } else if (!camerachange && Input.GetKey(KeyCode.E))
        {
            cameraSwitch.GetComponent<CameraSwitch>().setInBattle(false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            camerachange = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            camerachange = false;
        }
    }
}
