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

	void Start () {
        rb = GetComponent<Rigidbody>();
        enemy = GameObject.Find("Enemy");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Move();
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

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "EnemyTalkBox")
        {
            enemy.GetComponent<Enemy>().SetBattle(true);
        }
    }
}
