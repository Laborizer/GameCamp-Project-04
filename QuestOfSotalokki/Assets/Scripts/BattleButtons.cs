using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButtons : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;

    public GameObject attack;
    public GameObject specialMenu;
    public GameObject itemMenu;
    public GameObject battle;

    // Use this for initialization
    void Start () {
        specialMenu.SetActive(false);
        itemMenu.SetActive(false);
    }

    private void Update()
    {
        enemy = GameObject.Find("Enemy");
    }

    public void enableSpecialWindow()
    {
        specialMenu.SetActive(true);
        itemMenu.SetActive(false);
    }

    public void enableItemWindow()
    {
        itemMenu.SetActive(true);
        specialMenu.SetActive(false);
    }

    public void doAttack()
    {
        if (enemy != null)
        {
            enemy.GetComponent<Enemy>().health = enemy.GetComponent<Enemy>().health - player.GetComponent<Player>().attackDamage;
            if(enemy.GetComponent<Enemy>().health < 0)
            {
                enemy.GetComponent<Enemy>().health = 0;
            }
        }
    }
    public void useSpecialSkill()
    {
        if (enemy != null)
        {
            // Weakness to used skill
            if(enemy.GetComponent<Enemy>().weakness.Equals(battle.GetComponent<Battle>().specialSkill[0]))
            {
                enemy.GetComponent<Enemy>().health = enemy.GetComponent<Enemy>().health - (int.Parse(battle.GetComponent<Battle>().specialSkill[1]) * 2);
                player.GetComponent<Player>().mana = player.GetComponent<Player>().mana - int.Parse(battle.GetComponent<Battle>().specialSkill[2]);
            }
            // No weakness to used skill
            else
            {
                enemy.GetComponent<Enemy>().health = enemy.GetComponent<Enemy>().health - int.Parse(battle.GetComponent<Battle>().specialSkill[1]);
                player.GetComponent<Player>().mana = player.GetComponent<Player>().mana - int.Parse(battle.GetComponent<Battle>().specialSkill[2]);
            }
        }
    }

    public void disableMenus()
    {
        itemMenu.SetActive(false);
        specialMenu.SetActive(false);
    }
}
