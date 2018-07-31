using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPickUp : MonoBehaviour {

    GameObject soundManager;
    GameObject player;

    public string itemName;

	void Start () {
        itemName = transform.name.ToString();
        player = GameObject.Find("Player");
        soundManager = GameObject.Find("SoundManager");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            soundManager.GetComponent<SoundManager>().potionPickupPlay();
            player.GetComponent<Player>().givePotion(itemName);
            Destroy(this.gameObject);
        }
    }
}
