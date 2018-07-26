using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    public string talk;
    GameObject player;

    private void Start()
    {
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
}
