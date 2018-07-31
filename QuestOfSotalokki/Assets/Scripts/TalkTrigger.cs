using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkTrigger : MonoBehaviour {
    GameObject soundManager;

    public GameObject dialogueBox;
    public GameObject Buttons;
    public GameObject Enemy;
    public TextMeshProUGUI text;
    public string enemyName;
    private bool isTalking;

    private void Start()
    {
        isTalking = false;
        soundManager = GameObject.Find("SoundManager");
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag != "NPC")
        {
            enemyName = transform.parent.name;
            transform.parent.name = "Enemy";
            transform.parent.tag = "Enemy";
            if (enemyName == "FinalBoss")
            {
                Enemy = GameObject.Find("Enemy");
                Enemy.GetComponent<Enemy>().giveName(enemyName);
            }
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
            soundManager.GetComponent<SoundManager>().enemyTalkPlay();
            text.text = transform.parent.GetComponent<Enemy>().getName() + ":\n" + transform.parent.GetComponent<Enemy>().getText();
            dialogueBox.SetActive(true);
            transform.parent.GetComponent<Enemy>().SetWalk(false);
            isTalking = true;
        }

        if (col.gameObject.tag == "PlayerTag" && Input.GetKeyDown(KeyCode.E) && this.gameObject.tag == "NPC")
        {
            soundManager.GetComponent<SoundManager>().npcTalkPlay();
            text.text = transform.parent.GetComponent<NPC>().getName() + ":\n" + transform.parent.GetComponent<NPC>().getText();

            if (transform.parent.GetComponent<NPC>().getName() == "NPCStart")
            {
                Buttons.SetActive(true);
            }

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
            if (transform.parent.GetComponent<NPC>().getName() == "NPCStart")
            {
                Buttons.SetActive(false);
            }
            dialogueBox.SetActive(false);
            isTalking = false;
        }
    }
}
