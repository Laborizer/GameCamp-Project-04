using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource audiosource;

    public AudioClip button;
    public AudioClip enemyTalk;
    public AudioClip npcTalk;
    public AudioClip potionPickup;
    public AudioClip specialLearn;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void buttonSoundPlay()
    {
        audiosource.PlayOneShot(button, 1f);
    }

    public void enemyTalkPlay()
    {
        audiosource.PlayOneShot(enemyTalk, 1f);
    }

    public void npcTalkPlay()
    {
        audiosource.PlayOneShot(npcTalk, 1f);
    }

    public void potionPickupPlay()
    {
        audiosource.PlayOneShot(potionPickup, 1f);
    }

    public void specialLearnPlay()
    {
        audiosource.PlayOneShot(specialLearn, 1f);
    }
}
