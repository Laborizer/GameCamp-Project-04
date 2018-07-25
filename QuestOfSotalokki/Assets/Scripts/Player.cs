using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour {

    public float health;
    public float mana;
    public float moveSpeed;
    public float attackDamage;
    public float defense;

    public int healtPotionCount;
    public int manaPotionCount;
    public int attackPotionCount;
    public int defensePotionCount;

    // 0 = name, 1 = damage, 2 = cost
    public String[] special1;
    public String[] special2;
    public String[] special3;
    public String[] special4;
    // int.Parse(special1[1]);
    //String[] frostExplosion = new string[3];

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Boolean canMove;

    public GameObject dialogueBox;
    public TextMeshProUGUI text;

    void Start () {
        canMove = true;
        rb = GetComponent<Rigidbody>();
        attackDamage = 20;
        defense = 0;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (canMove)
        {
            Move();
        }
        if (Input.GetKeyDown(KeyCode.E) && dialogueBox.activeSelf)
        {
            dialogueBox.SetActive(false);
            setMove(true);
        }
    }

    public void Die()
    {
        this.gameObject.SetActive(false);
    }

    private void Move()
    {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"),0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;
        rb.velocity = moveVelocity;
    }

    internal void givePotion(string itemName)
    {
        string name = "";
        if (itemName == "HealtPotion")
        {
            healtPotionCount++;
            name = "Health potion";
        }
        if (itemName == "ManaPotion")
        {
            manaPotionCount++;
            name = "Mana potion";
        }
        if (itemName == "AttackPotion")
        {
            attackPotionCount++;
            name = "Attack potion";
        }
        if (itemName == "DefensePotion")
        {
            defensePotionCount++;
            name = "Defence potion";
        }

        dialogueBox.SetActive(true);
        text.text = "You is gettings new " + name;
        setMove(false);
    }

    internal void setMove(bool result)
    {
        canMove = result;
        if (result == false)
        {
            rb.velocity = Vector3.zero;
        }
    }

    internal void giveSpell(string[] spellInfo)
    {
        String infotext = "";
        if (special1[0].Equals(""))
        {
            special1 = spellInfo;
            infotext = "You is leaned " + spellInfo[0];
        }
        else if (special2[0].Equals(""))
        {
            special2 = spellInfo;
            infotext = "You is leaned " + spellInfo[0];
        }
        else if (special3[0].Equals(""))
        {
            special3 = spellInfo;
            infotext = "You is leaned " + spellInfo[0];
        }
        else if (special4[0].Equals(""))
        {
            special4 = spellInfo;
            infotext = "You is leaned " + spellInfo[0];
        }
        else
        {
            // does something
            infotext = "You is of learned nothings new";
        }
        dialogueBox.SetActive(true);
        text.text = infotext;
        setMove(false);
    }
}
