using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameObject enemy;

    public float moveSpeed;
    public int healtPotionCount;

    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Boolean canMove;

	void Start () {
        canMove = true;
        rb = GetComponent<Rigidbody>();
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (canMove)
        {
            Move();
        }
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
