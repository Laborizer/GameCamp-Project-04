using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource audiosource;
    float randomVolume;

    public GameObject overworldTheme;
    public GameObject battleTheme;

    public AudioClip button;
    public AudioClip enemyTalk;
    public AudioClip npcTalk;
    public AudioClip potionPickup;
    public AudioClip specialLearn;
    public AudioClip walk;
    public AudioClip gulp;

    public AudioClip shotgun;
    public AudioClip fire;
    public AudioClip thunder;
    public AudioClip ice;
    public AudioClip hit;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        randomVolume = 0;
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

    // sound effects
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
    public void walkPlay()
    {
        if(!audiosource.isPlaying)
        {
            randomVolume = Random.Range(5.5f, 6f);
            audiosource.pitch = Random.Range(0.8f, 1.1f);
            audiosource.PlayOneShot(walk, randomVolume);
        }
    }
    public void potionDrinkPlay()
    {
        audiosource.PlayOneShot(gulp, 15f);
    }

    // skill sound effects
    public void shotgunPlay()
    {
        audiosource.PlayOneShot(shotgun, 2f);
    }
    public void firePlay()
    {
        audiosource.PlayOneShot(fire, 2f);
    }
    public void thunderPlay()
    {
        audiosource.PlayOneShot(thunder, 2f);
    }
    public void icePlay()
    {
        audiosource.PlayOneShot(ice, 5f);
    }
    public void hitPlay()
    {
        audiosource.PlayOneShot(hit, 3f);
    }
}
