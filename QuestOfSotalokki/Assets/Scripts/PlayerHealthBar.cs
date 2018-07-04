using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{

    GameObject player;

    public float fillAmount;
    public Image content;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        fillAmount = player.GetComponent<Player>().health / 100;
        HandleBar();
    }

    private void HandleBar()
    {
        content.fillAmount = fillAmount;
    }
}