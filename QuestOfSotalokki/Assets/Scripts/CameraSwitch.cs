using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
    GameObject soundManager;

    public bool inBattle;

    public Camera overworldCam;
    public Camera battleCam;

    // Use this for initialization
    void Start () {
        soundManager = GameObject.Find("SoundManager");
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
            soundManager.GetComponent<SoundManager>().battleThemePlay();
        }
        else
        {
            overworldCam.enabled = true;
            battleCam.enabled = false;
            soundManager.GetComponent<SoundManager>().overworldThemePlay();
        }
    }

    public void setInBattle(Boolean result)
    {
        inBattle = result;
    }
}
