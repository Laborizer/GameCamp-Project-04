using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickUp : MonoBehaviour {

    GameObject player;

    public string itemName;

	void Start () {
        itemName = transform.name.ToString();
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            player.GetComponent<Player>().givePotion(itemName);
            Destroy(this.gameObject);
        }
    }
}
