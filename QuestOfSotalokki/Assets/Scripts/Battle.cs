using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;

    public bool inBattle;
    public GameObject cameras;
    public GameObject items;
    public GameObject buttons;

    bool playerTurn;
    int skill;

	// Use this for initialization
	void Start () {
        playerTurn = true;
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
	}

    private void combat()
    {
        if(!playerTurn)
        {
            buttons.SetActive(false);
            enemyRandomizeAttack();
            attackPlayer();
        }
        else
        {
            buttons.SetActive(true);
        }
    }

    private void attackPlayer()
    {
        player.GetComponent<Player>().health = player.GetComponent<Player>().health - (skill - player.GetComponent<Player>().defense);
        items.GetComponent<ItemMenu>().playerTurn = true;
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
}
