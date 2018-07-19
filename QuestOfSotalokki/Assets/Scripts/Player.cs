using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Boolean canMove;

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
        if (itemName == "HealtPotion")
        {
            healtPotionCount++;
        }
        if (itemName == "ManaPotion")
        {
            manaPotionCount++;
        }
        if (itemName == "AttackPotion")
        {
            attackPotionCount++;
        }
        if (itemName == "DefensePotion")
        {
            defensePotionCount++;
        }
    }

    internal void setMove(bool result)
    {
        canMove = result;
        if (result == false)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
