using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health;

    GameObject cameraSwitch;
    GameObject player;
    Boolean walk;

    public float speed;
    public Transform target;

    public String talk;

    public int skill1;
    public int skill2;
    public int skill3;
    public int skill4;

    void Start () {
        player = GameObject.Find("Player");
        walk = false;
        cameraSwitch = GameObject.Find("Cameras");
    }

    private void Update()
    {
        if (walk)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            player.GetComponent<Player>().setMove(true);
        }
    }

    public void SetBattle(bool result)
    {
        cameraSwitch.GetComponent<CameraSwitch>().setInBattle(result);
    }

    public void SetWalk(bool result)
    {
        walk = result;
        player.GetComponent<Player>().setMove(result);
    }

    public String getText()
    {
        return talk;
    }

    internal string getName()
    {
        return this.gameObject.name;
    }
}
