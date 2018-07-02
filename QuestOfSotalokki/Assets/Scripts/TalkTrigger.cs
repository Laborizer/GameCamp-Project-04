using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkTrigger : MonoBehaviour {

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "PlayerTag" && Input.GetKey(KeyCode.E))
        {
            transform.parent.GetComponent<Enemy>().SetBattle(true);
        }

        if (col.gameObject.tag == "PlayerTag")
        {
            transform.parent.GetComponent<Enemy>().SetWalk(false);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "PlayerTag")
        {
            transform.parent.GetComponent<Enemy>().SetBattle(false);
        }
    }
}
