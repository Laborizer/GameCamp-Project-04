using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        healthPotionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Health potion x " + player.GetComponent<Player>().healtPotionCount;
        manaPotionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Mana potion x " + player.GetComponent<Player>().manaPotionCount;
        attackPotionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Attack potion x " + player.GetComponent<Player>().attackPotionCount;
        defensePotionButton.GetComponentInChildren<TextMeshProUGUI>().text = "Defense potion x " + player.GetComponent<Player>().defensePotionCount;
    }

    public void useHealthPotion()
    {
        player.GetComponent<Player>().healtPotionCount--;
        player.GetComponent<Player>().health = player.GetComponent<Player>().health + 50;
        if(player.GetComponent<Player>().health > 100)
        {
            player.GetComponent<Player>().health = 100;
        }
    }
    public void useManaPotion()
    {
        player.GetComponent<Player>().manaPotionCount--;
        player.GetComponent<Player>().mana = player.GetComponent<Player>().mana + 50;
        if (player.GetComponent<Player>().mana > 100)
        {
            player.GetComponent<Player>().mana = 100;
        }
    }
    public void useAttackPotion()
    {
        player.GetComponent<Player>().attackPotionCount--;
        player.GetComponent<Player>().attackDamage = player.GetComponent<Player>().attackDamage * 1.5f;
    }
    public void useDefensePotion()
    {
        player.GetComponent<Player>().defensePotionCount--;
        player.GetComponent<Player>().defense = player.GetComponent<Player>().defense + 5;
    }

    public void disablePlayerTurn()
    {
        playerTurn = false;
    }
}
