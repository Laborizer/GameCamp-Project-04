using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAnimations : MonoBehaviour {
    public GameObject soundManager;

    // Spell sprites
    public GameObject fire;
    public GameObject thunder;
    public GameObject ice;
    public GameObject shotgun;
    public GameObject hit;

    public GameObject playerSprite;
    public GameObject enemySprite;

    public bool skillAnimationOn;
    public bool animationDone;

    float countdown;
    bool soundPlayed;

    // Use this for initialization
    void Start () {
        soundManager = GameObject.Find("SoundManager");
        skillAnimationOn = false;
        animationDone = false;
        countdown = 0;
        soundPlayed = false;
    }
	
	public void fireOnEnemy()
    {
        skillAnimationOn = true;

        if (countdown >= 2)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            fire.SetActive(false);
            soundPlayed = false;
        }
        else if (countdown < 2)
        {
            if(!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().firePlay();
                soundPlayed = true;
            }
            fire.transform.position = enemySprite.transform.position;
            fire.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }
    public void fireOnPlayer()
    {
        skillAnimationOn = true;

        if (countdown >= 2)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            fire.SetActive(false);
            soundPlayed = false;
        }
        else if (countdown < 2)
        {
            if (!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().firePlay();
                soundPlayed = true;
            }
            fire.transform.position = playerSprite.transform.position;
            fire.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }

    public void thunderOnEnemy()
    {
        skillAnimationOn = true;

        if (countdown >= 2)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            thunder.SetActive(false);
            soundPlayed = false;
        }
        else if (countdown < 2)
        {
            if (!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().thunderPlay();
                soundPlayed = true;
            }
            thunder.transform.position = enemySprite.transform.position;
            thunder.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }
    public void thunderOnPlayer()
    {
        skillAnimationOn = true;

        if (countdown >= 2)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            thunder.SetActive(false);
            soundPlayed = true;
        }
        else if (countdown < 2)
        {
            if (!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().thunderPlay();
                soundPlayed = true;
            }
            thunder.transform.position = playerSprite.transform.position;
            thunder.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }

    public void iceOnEnemy()
    {
        skillAnimationOn = true;

        if (countdown >= 2)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            ice.SetActive(false);
            soundPlayed = false;
        }
        else if (countdown < 2)
        {
            if (!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().icePlay();
                soundPlayed = true;
            }
            ice.transform.position = enemySprite.transform.position;
            ice.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }
    public void iceOnPlayer()
    {
        skillAnimationOn = true;

        if (countdown >= 2)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            ice.SetActive(false);
            soundPlayed = false;
        }
        else if (countdown < 2)
        {
            if (!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().icePlay();
                soundPlayed = true;
            }
            ice.transform.position = playerSprite.transform.position;
            ice.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }

    public void shotgunOnEnemy()
    {
        skillAnimationOn = true;

        if (countdown >= 2)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            shotgun.SetActive(false);
            soundPlayed = false;
        }
        else if (countdown < 2)
        {
            if (!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().shotgunPlay();
                soundPlayed = true;
            }
            shotgun.transform.position = enemySprite.transform.position;
            shotgun.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }
    public void shotgunOnPlayer()
    {
        skillAnimationOn = true;

        if (countdown >= 2)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            shotgun.SetActive(false);
            soundPlayed = false;
        }
        else if (countdown < 2)
        {
            if (!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().shotgunPlay();
                soundPlayed = true;
            }
            shotgun.transform.position = playerSprite.transform.position;
            shotgun.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }

    public void hitOnEnemy()
    {
        skillAnimationOn = true;

        if (countdown >= 1)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            hit.SetActive(false);
            soundPlayed = false;
        }
        else if (countdown < 1)
        {
            if (!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().hitPlay();
                soundPlayed = true;
            }
            hit.transform.position = enemySprite.transform.position;
            hit.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }
    public void hitOnPlayer()
    {
        skillAnimationOn = true;

        if (countdown >= 1)
        {
            countdown = 0;
            skillAnimationOn = false;
            animationDone = true;
            hit.SetActive(false);
            soundPlayed = false;
        }
        else if (countdown < 1)
        {
            if (!soundPlayed)
            {
                soundManager.GetComponent<SoundManager>().hitPlay();
                soundPlayed = true;
            }
            hit.transform.position = playerSprite.transform.position;
            hit.SetActive(true);
        }

        countdown = countdown + Time.deltaTime;
    }
}
