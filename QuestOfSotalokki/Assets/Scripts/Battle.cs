using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {

    public GameObject enemy;

    public bool inBattle;
    public GameObject cameras;
    public GameObject buttons;

    bool playerTurn;

	// Use this for initialization
	void Start () {
        playerTurn = true;
	}
	
	// Update is called once per frame
	void Update () {
        enemy = GameObject.Find("Enemy");
        inBattle = cameras.GetComponent<CameraSwitch>().inBattle;
        playerTurn = buttons.GetComponent<BattleButtons>().playerTurn;

        if(inBattle)
        {
            combat();
        }
        else
        {
            buttons.GetComponent<BattleButtons>().playerTurn = true;
        }
	}

    private void combat()
    {
        if(!playerTurn)
        {

        }
    }
}
