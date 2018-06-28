using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            transform.parent.GetComponent<Enemy>().SetBattle(true);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            transform.parent.GetComponent<Enemy>().SetBattle(false);
        }
    }
}
