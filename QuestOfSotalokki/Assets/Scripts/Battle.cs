using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public GameObject battleLog;

    public bool inBattle;
    public GameObject cameras;
    public GameObject items;
    public GameObject buttons;
    public GameObject gameOverUI;

    bool doCountdown;
    public bool usedAttack;
    bool attackButtonPressed;
    bool playerTurn;
    bool enemyAttacked;
    int skill;
    float countdown;

	// Use this for initialization
	void Start () {
        doCountdown = false;
        usedAttack = false;
        playerTurn = true;
        countdown = 0;
        attackButtonPressed = false;
        enemyAttacked = false;
	}
	
	// Update is called once per frame
	void Update () {
        enemy = GameObject.Find("Enemy");
        inBattle = cameras.GetComponent<CameraSwitch>().inBattle;
        playerTurn = items.GetComponent<ItemMenu>().playerTurn;

        if(inBattle)
        {
            combat();
        }
        else
        {
            items.GetComponent<ItemMenu>().playerTurn = true;
            player.GetComponent<Player>().health = 100;
            player.GetComponent<Player>().attackDamage = 20;
            player.GetComponent<Player>().defense = 0;
        }

        if (player.GetComponent<Player>().health <= 0)
        {
            cameras.GetComponent<CameraSwitch>().setInBattle(false);
            player.GetComponent<Player>().Die();
            gameOverUI.SetActive(true);
        }

        if(attackButtonPressed && playerTurn)
        {
            playerAttack();
        }
	}

    private void playerAttack()
    {
        battleLog.GetComponentInChildren<Text>().text = "Player attacks!";
        buttons.SetActive(false);
        doCountdown = true;

        if (countdown >= 4)
        {
            doCountdown = false;
            usedAttack = false;
            countdown = 0;
            battleLog.SetActive(false);
            attackButtonPressed = false;
            items.GetComponent<ItemMenu>().playerTurn = false;
        }
        else if (countdown >= 3 && !usedAttack)
        {
            buttons.GetComponent<BattleButtons>().doAttack();
            usedAttack = true;
        }
        else if (countdown >= 1)
        {
            battleLog.SetActive(true);
        }

        if(doCountdown)
        {
            countdown = countdown + Time.deltaTime;
        }
    }

    private void combat()
    {
        if(!playerTurn)
        {
            doCountdown = true;
            battleLog.GetComponentInChildren<Text>().text = "Enemy attacks!";
            buttons.SetActive(false);

            if (countdown >= 4)
            {
                doCountdown = false;
                items.GetComponent<ItemMenu>().playerTurn = true;
                countdown = 0;
                battleLog.SetActive(false);
                enemyAttacked = false;
            }
            else if(countdown >= 3 && !enemyAttacked)
            {
                enemyRandomizeAttack();
                attackPlayer();
                enemyAttacked = true;
            }
            else if (countdown >= 1)
            {
                battleLog.SetActive(true);
            }

            if(doCountdown)
            {
                countdown = countdown + Time.deltaTime;
            }
        }
        else
        {
            buttons.SetActive(true);
        }
    }

    private void attackPlayer()
    {
        player.GetComponent<Player>().health = player.GetComponent<Player>().health - (skill - player.GetComponent<Player>().defense);
    }

    private void enemyRandomizeAttack()
    {
        skill = UnityEngine.Random.Range(1, 5);

        switch (skill) {
            case 1:
                skill = enemy.GetComponent<Enemy>().skill1;
                break;
            case 2:
                skill = enemy.GetComponent<Enemy>().skill2;
                break;
            case 3:
                skill = enemy.GetComponent<Enemy>().skill3;
                break;
            case 4:
                skill = enemy.GetComponent<Enemy>().skill4;
                break;
        }
    }

    public void playerUsedAttack()
    {
        attackButtonPressed = true;
    }
}
