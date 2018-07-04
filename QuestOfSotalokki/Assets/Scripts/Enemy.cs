using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health;

    GameObject cameraSwitch;
    Boolean walk;

    public float speed;
    public Transform target;

    void Start () {
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
    }

    public void SetBattle(bool result)
    {
        cameraSwitch.GetComponent<CameraSwitch>().setInBattle(result);
    }

    public void SetWalk(bool result)
    {
        walk = result;
    }
}
