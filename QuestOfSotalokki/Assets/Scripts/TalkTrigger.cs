﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkTrigger : MonoBehaviour {
    public GameObject dialogueBox;
    public TextMeshProUGUI text;
    private bool isTalking;

    private void Start()
    {
        isTalking = false;
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag != "NPC")
        {
            transform.parent.name = "Enemy";
            transform.parent.tag = "Enemy";
        }

        if (col.gameObject.tag == "PlayerTag" && Input.GetKeyDown(KeyCode.E) && this.gameObject.tag == "Enemy")
        {
            if(!isTalking)
            {
                dialogueBox.SetActive(true);
                isTalking = true;
            }
            else
            {
                dialogueBox.SetActive(false);
                transform.parent.GetComponent<Enemy>().SetBattle(true);
            }
        }

        if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag == "Enemy" && !isTalking)
        {
            text.text = transform.parent.GetComponent<Enemy>().getName() + ":\n" + transform.parent.GetComponent<Enemy>().getText();
            dialogueBox.SetActive(true);
            transform.parent.GetComponent<Enemy>().SetWalk(false);
            isTalking = true;
        }

        if (col.gameObject.tag == "PlayerTag" && Input.GetKeyDown(KeyCode.E) && this.gameObject.tag == "NPC")
        {
            text.text = transform.parent.GetComponent<NPC>().getName() + ":\n" + transform.parent.GetComponent<NPC>().getText();

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
            dialogueBox.SetActive(false);
        }
        else if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag == "NPC")
        {
            dialogueBox.SetActive(false);
            isTalking = false;
        }
    }
}
