using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choise : MonoBehaviour {

    public GameObject player;

    public void RedPill()
    {
        Application.Quit();
    }

    public void BluePill()
    {
        player.GetComponent<Player>().startPos();
    }
}
