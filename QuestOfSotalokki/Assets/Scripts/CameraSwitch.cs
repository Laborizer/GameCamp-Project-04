using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public bool inBattle;
    public bool inHandGame;

    public Camera overworldCam;
    public Camera battleCam;
    public Camera HandGame;

    // Use this for initialization
    void Start () {
        inBattle = false;
        inHandGame = false;
        overworldCam.enabled = true;
        battleCam.enabled = false;
        HandGame.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        checkIfBattle();
        cheackHandGame();
	}

    private void cheackHandGame()
    {
        if (inHandGame)
        {
            overworldCam.enabled = false;
            HandGame.enabled = true;
        } else
        {
            overworldCam.enabled = true;
            HandGame.enabled = false;
        }
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

    public void setInBattle(Boolean result)
    {
        inBattle = result;
    }

    internal void setHandgame(bool result)
    {
        inHandGame = result;
    }
}
