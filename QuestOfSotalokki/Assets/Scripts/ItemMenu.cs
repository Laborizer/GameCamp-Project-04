﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour {

    public Button healthPotionButton;
    public Button manaPotionButton;
    public Button attackPotionButton;
    public Button defensePotionButton;

    public bool playerTurn;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerTurn = true;
    }
	
	// Update is called once per frame
	void Update () {
        healthPotionButton.GetComponentInChildren<Text>().text = "Health potion x " + player.GetComponent<Player>().healtPotionCount;
        manaPotionButton.GetComponentInChildren<Text>().text = "Mana potion x " + player.GetComponent<Player>().manaPotionCount;
        attackPotionButton.GetComponentInChildren<Text>().text = "Attack potion x " + player.GetComponent<Player>().attackPotionCount;
        defensePotionButton.GetComponentInChildren<Text>().text = "Defense potion x " + player.GetComponent<Player>().defensePotionCount;
    }

    public void useHealthPotion()
    {
        player.GetComponent<Player>().healtPotionCount--;
        player.GetComponent<Player>().health = player.GetComponent<Player>().health + 50;
        if(player.GetComponent<Player>().health > 100)
        {
            player.GetComponent<Player>().health = 100;
        }
        disablePlayerTurn();
    }
    public void useManaPotion()
    {
        player.GetComponent<Player>().manaPotionCount--;
        disablePlayerTurn();
    }
    public void useAttackPotion()
    {
        player.GetComponent<Player>().attackPotionCount--;
        player.GetComponent<Player>().attackDamage = player.GetComponent<Player>().attackDamage * 1.5f;
        disablePlayerTurn();
    }
    public void useDefensePotion()
    {
        player.GetComponent<Player>().defensePotionCount--;
        player.GetComponent<Player>().defense = player.GetComponent<Player>().defense + 5;
        disablePlayerTurn();
    }

    public void disablePlayerTurn()
    {
        playerTurn = false;
    }
}
