using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {
    GameObject soundManager;

	// Use this for initialization
	void Start () {
        soundManager = GameObject.Find("SoundManager");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            soundManager.GetComponent<SoundManager>().walkPlay();
        }
	}
}
