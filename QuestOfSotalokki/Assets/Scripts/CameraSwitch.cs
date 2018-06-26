using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public bool inBattle;

    public Camera overworldCam;
    public Camera battleCam;

    // Use this for initialization
    void Start () {
        inBattle = false;
        overworldCam.enabled = true;
        battleCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        checkIfBattle();
	}

    private void checkIfBattle()
    {
        if(inBattle)
        {
            overworldCam.enabled = false;
            battleCam.enabled = true;
        }
        else
        {
            overworldCam.enabled = true;
            battleCam.enabled = false;
        }
    }
}
