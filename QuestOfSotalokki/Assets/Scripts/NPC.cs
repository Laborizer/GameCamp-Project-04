using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public string talk;
    GameObject cameraSwitch;
    GameObject player;

    private void Start()
    {
        cameraSwitch = GameObject.Find("Cameras");
        player = GameObject.Find("Player");
    }
    internal string getText()
    {
        return talk;
    }

    internal string getName()
    {
        return this.gameObject.name;
    }

    internal void setHandgame(bool result)
    {
        cameraSwitch.GetComponent<CameraSwitch>().setHandgame(result);
    }

    public void SetWalk(bool result)
    {
        player.GetComponent<Player>().setMove(result);
    }
}
