using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    GameObject enemy;

    public float fillAmount;
    public Image content;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.Find("Enemy");

        fillAmount = enemy.GetComponent<Enemy>().health / 100;
        HandleBar();
    }

    private void HandleBar()
    {
        content.fillAmount = fillAmount;
    }
}