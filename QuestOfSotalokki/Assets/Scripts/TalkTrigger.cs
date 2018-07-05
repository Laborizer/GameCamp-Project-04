using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkTrigger : MonoBehaviour {
    public GameObject dialogueBox;
    private bool isTalking;

    private void Start()
    {
        isTalking = false;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "PlayerTag" && Input.GetKeyDown(KeyCode.E) && this.gameObject.tag == "Enemy")
        {
            if(!isTalking)
            {
                dialogueBox.SetActive(true);
                isTalking = true;
            }
            else
            {
                isTalking = false;
                dialogueBox.SetActive(false);
                transform.parent.GetComponent<Enemy>().SetBattle(true);
            }
        }

        if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag == "Enemy")
        {
            dialogueBox.GetComponentInChildren<Text>().text = "Enemy:" + Environment.NewLine + "Are you wanna die!?";
            dialogueBox.SetActive(true);
            transform.parent.GetComponent<Enemy>().SetWalk(false);
        }

        if (col.gameObject.tag == "PlayerTag" && Input.GetKeyDown(KeyCode.E) && this.gameObject.tag == "NPC")
        {
            dialogueBox.GetComponentInChildren<Text>().text = "NPC:" + Environment.NewLine + "Hello! I provide you with zero information, therefore I am pretty useless. However, I can do a few neat magic tricks. Wanna see?";

            if (!isTalking)
            {
                isTalking = true;
                dialogueBox.SetActive(true);
            }
            else
            {
                isTalking = false;
                dialogueBox.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag == "Enemy")
        {
            transform.parent.GetComponent<Enemy>().SetBattle(false);
        }
        else if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag == "NPC")
        {
            dialogueBox.SetActive(false);
            isTalking = false;
        }
    }
}
