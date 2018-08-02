using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimationScript : MonoBehaviour {

    Animator animator;
    bool Up;
    bool Down;
    bool Left;
    bool Right;

	void Start () {
        animator = gameObject.GetComponent<Animator>();
    }
	
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Up",true);
        } else if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Down", true);
        } else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Left", true);
        } else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Right", true);
        }
        else {
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
	}
}
