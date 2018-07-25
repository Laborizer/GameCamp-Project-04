using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour {

    GameObject player;

    // 0 = name, 1 = damage, 2 = cost
    public String[] SpellInfo;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            player.GetComponent<Player>().giveSpell(SpellInfo);
            Destroy(this.gameObject);
        }
    }
}
