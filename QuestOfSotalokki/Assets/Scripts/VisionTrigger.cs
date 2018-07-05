using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionTrigger : MonoBehaviour {
    public GameObject dialogueBox;

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
            dialogueBox.SetActive(true);
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
