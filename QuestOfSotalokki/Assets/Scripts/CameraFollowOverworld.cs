using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowOverworld : MonoBehaviour {

    public Transform target;

    private Vector3 offset;

    public float smoothFactor = 0.9f;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate () {
        Vector3 newPos = target.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }
}
