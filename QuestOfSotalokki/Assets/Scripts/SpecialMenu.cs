using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpecialMenu : MonoBehaviour
{

    public Button special1Button;
    public Button special2Button;
    public Button special3Button;
    public Button special4Button;

    public bool playerTurn;

    GameObject player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        playerTurn = true;
    }

    // Update is called once per frame
    void Update()
    {
        special1Button.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Player>().special1[0];
        special2Button.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Player>().special2[0];
        special3Button.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Player>().special3[0];
        special4Button.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Player>().special4[0];
    }

    public void useHealthPotion()
    {
        player.GetComponent<Player>().healtPotionCount--;
        player.GetComponent<Player>().health = player.GetComponent<Player>().health + 50;
        if (player.GetComponent<Player>().health > 100)
        {
            player.GetComponent<Player>().health = 100;
        }
    }
    public void useManaPotion()
    {
        player.GetComponent<Player>().manaPotionCount--;
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
