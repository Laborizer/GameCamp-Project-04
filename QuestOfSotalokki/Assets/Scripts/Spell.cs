﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    GameObject soundManager;
    GameObject player;

    // 0 = name, 1 = damage, 2 = cost
    public String[] SpellInfo;

    void Start()
    {
        player = GameObject.Find("Player");
        soundManager = GameObject.Find("SoundManager");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            soundManager.GetComponent<SoundManager>().specialLearnPlay();
            player.GetComponent<Player>().giveSpell(SpellInfo);
            Destroy(this.gameObject);
        }
    }
}
