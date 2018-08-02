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
    public GameObject Player;
    public TextMeshProUGUI text;
    public string enemyName;
    public bool isTalkingNPC = false;
    public bool isTalkingEnemy = false;
    public bool hasPlayed = false;
    public float timer;

    private void Start()
    {
        soundManager = GameObject.Find("SoundManager");
        Player = GameObject.Find("Player");
        timer = 0.5f;
    }

    private void Update()
    {
        if (isTalkingEnemy)
        {
            transform.parent.GetComponent<Enemy>().SetWalk(false);
            timer -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.E) && timer <= 0F)
            {
                dialogueBox.SetActive(false);
                transform.parent.GetComponent<Enemy>().SetBattle(true);
                Player.GetComponent<Player>().setBattle(true);
                isTalkingEnemy = false;
            }
        }

        if (isTalkingNPC)
        {
            if (!dialogueBox.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                dialogueBox.SetActive(true);
                soundManager.GetComponent<SoundManager>().npcTalkPlay();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
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
            } else if (enemyName == "EnemyELP")
            {
                Enemy = GameObject.Find("Enemy");
                Enemy.GetComponent<Enemy>().giveName(enemyName);
            } else if (enemyName == "EnemyGIF")
            {
                Enemy = GameObject.Find("Enemy");
                Enemy.GetComponent<Enemy>().giveName(enemyName);
            } else if (enemyName == "FireBoss")
            {
                Enemy = GameObject.Find("Enemy");
                Enemy.GetComponent<Enemy>().giveName(enemyName);
            } else if (enemyName == "IceBoss")
            {
                Enemy = GameObject.Find("Enemy");
                Enemy.GetComponent<Enemy>().giveName(enemyName);
            } else if (enemyName == "ThunderBoss")
            {
                Enemy = GameObject.Find("Enemy");
                Enemy.GetComponent<Enemy>().giveName(enemyName);
            } else if (enemyName == "ShotgunBoss")
            {
                Enemy = GameObject.Find("Enemy");
                Enemy.GetComponent<Enemy>().giveName(enemyName);
            } else if (enemyName == "EnemySnake")
            {
                Enemy = GameObject.Find("Enemy");
                Enemy.GetComponent<Enemy>().giveName(enemyName);
            }
        }

        if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag == "Enemy" && !isTalkingEnemy)
        {
            if (!hasPlayed)
            {
                soundManager.GetComponent<SoundManager>().enemyTalkPlay();
                hasPlayed = true;
            }
            text.text = transform.parent.GetComponent<Enemy>().getName() + ":\n" + transform.parent.GetComponent<Enemy>().getText();
            dialogueBox.SetActive(true);
            isTalkingEnemy = true;
        }

        if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag == "NPC")
        {
            text.text = transform.parent.GetComponent<NPC>().getName() + ":\n" + transform.parent.GetComponent<NPC>().getText();
            if (transform.parent.GetComponent<NPC>().getName() == "Mysterious Cat")
            {
                Buttons.SetActive(true);
            }
            isTalkingNPC = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag == "Enemy")
        {
            transform.parent.GetComponent<Enemy>().SetBattle(false);
            dialogueBox.SetActive(false);
            isTalkingEnemy = false;
        }
        else if (col.gameObject.tag == "PlayerTag" && this.gameObject.tag == "NPC")
        {
            if (transform.parent.GetComponent<NPC>().getName() == "Mysterious Cat")
            {
                Buttons.SetActive(false);
            }
            dialogueBox.SetActive(false);
            isTalkingNPC = false;
        }
    }
}
