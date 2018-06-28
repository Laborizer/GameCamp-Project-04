using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : MonoBehaviour {

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "Player" && Input.GetKey(KeyCode.E))
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
