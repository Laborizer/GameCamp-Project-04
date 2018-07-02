using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour {

    public Button healthPotionButton;
    public Button manaPotionButton;
    public Button attackPotionButton;
    public Button defensePotionButton;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
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
        if(player.GetComponent<Player>().healtPotionCount > 0)
        {
            player.GetComponent<Player>().healtPotionCount--;
        }
    }
    public void useManaPotion()
    {
        if (player.GetComponent<Player>().manaPotionCount > 0)
        {
            player.GetComponent<Player>().manaPotionCount--;
        }
    }
    public void useAttackPotion()
    {
        if (player.GetComponent<Player>().attackPotionCount > 0)
        {
            player.GetComponent<Player>().attackPotionCount--;
        }
    }
    public void useDefensePotion()
    {
        if (player.GetComponent<Player>().defensePotionCount > 0)
        {
            player.GetComponent<Player>().defensePotionCount--;
        }
    }
}
