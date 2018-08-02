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
        special1Button.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Player>().special1[0] + " " + player.GetComponent<Player>().special1[2];
        special2Button.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Player>().special2[0] + " " + player.GetComponent<Player>().special2[2];
        special3Button.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Player>().special3[0] + " " + player.GetComponent<Player>().special3[2];
        special4Button.GetComponentInChildren<TextMeshProUGUI>().text = player.GetComponent<Player>().special4[0] + " " + player.GetComponent<Player>().special4[2];
    }
}
