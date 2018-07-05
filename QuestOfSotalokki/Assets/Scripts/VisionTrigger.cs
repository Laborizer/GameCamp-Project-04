using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisionTrigger : MonoBehaviour {

    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "PlayerTag")
        {
            transform.parent.GetComponent<Enemy>().SetWalk(true);
            player.GetComponent<Player>().setMove(false);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "PlayerTag")
        {
            transform.parent.GetComponent<Enemy>().SetWalk(false);
        }
    }
}
