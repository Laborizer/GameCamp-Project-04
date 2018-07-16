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
            //specialMenu.SetActive(false);
            //itemMenu.SetActive(false);
            if (enemy.GetComponent<Enemy>().health <= 0)
            {
                enemy.GetComponent<Enemy>().SetBattle(false);
            }
        }
    }
}
