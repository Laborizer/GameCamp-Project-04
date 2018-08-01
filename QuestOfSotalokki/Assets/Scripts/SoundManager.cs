using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource audiosource;

    public GameObject overworldTheme;
    public GameObject battleTheme;

    public AudioClip button;
    public AudioClip enemyTalk;
    public AudioClip npcTalk;
    public AudioClip potionPickup;
    public AudioClip specialLearn;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void overworldThemePlay()
    {
        overworldTheme.SetActive(true);
        battleTheme.SetActive(false);
    }
    public void battleThemePlay()
    {
        battleTheme.SetActive(true);
        overworldTheme.SetActive(false);
    }

    public void buttonSoundPlay()
    {
        audiosource.PlayOneShot(button, 2f);
    }
    public void enemyTalkPlay()
    {
        audiosource.PlayOneShot(enemyTalk, 3f);
    }
    public void npcTalkPlay()
    {
        audiosource.PlayOneShot(npcTalk, 3f);
    }
    public void potionPickupPlay()
    {
        audiosource.PlayOneShot(potionPickup, 3f);
    }
    public void specialLearnPlay()
    {
        audiosource.PlayOneShot(specialLearn, 3f);
    }
}
