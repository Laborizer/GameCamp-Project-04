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
        manaPotionButton.GetComponentInChildren<Text>().text = "Mana potion x ";
        attackPotionButton.GetComponentInChildren<Text>().text = "Attack potion x ";
        defensePotionButton.GetComponentInChildren<Text>().text = "Defense potion x ";
    }
}
