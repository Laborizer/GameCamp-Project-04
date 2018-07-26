using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    GameObject player;
    GameObject cameraSwitch;

    private void Start()
    {
        player = GameObject.Find("Player");
        cameraSwitch = GameObject.Find("Cameras");
    }
    private void OnMouseDown()
    {
        player.transform.Translate(Vector3.zero);
        cameraSwitch.GetComponent<CameraSwitch>().setHandgame(false);
    }
}
