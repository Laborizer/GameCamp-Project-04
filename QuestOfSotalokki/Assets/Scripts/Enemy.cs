using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    GameObject cameraSwitch;

    void Start () {
        cameraSwitch = GameObject.Find("Cameras");
    }

    public void SetBattle(bool result)
    {
        cameraSwitch.GetComponent<CameraSwitch>().setInBattle(result);
    }
}
