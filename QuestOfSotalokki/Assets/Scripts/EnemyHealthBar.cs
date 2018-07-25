using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{

    GameObject enemy;

    public float fillAmount;
    public Image content;
    public TextMeshProUGUI text;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.Find("Enemy");
        if (enemy != null)
        {
            fillAmount = enemy.GetComponent<Enemy>().health / 100;
            text.SetText(enemy.GetComponent<Enemy>().health.ToString() + "/100");
        }
        HandleBar();
    }

    private void HandleBar()
    {
        content.fillAmount = fillAmount;
    }
}