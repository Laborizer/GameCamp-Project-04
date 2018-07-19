using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Battle : MonoBehaviour {

    public GameObject enemy;
    public GameObject player;
    public GameObject battleLog;

    public bool inBattle;
    public GameObject cameras;
    public GameObject items;
    public GameObject buttons;
    public GameObject gameOverUI;

    String enemySkillName;
    bool doCountdown;
    bool actionDone;
    bool attackButtonPressed;
    bool enemyAttacked;
    int skill;
    float countdown;
    bool randomizeDone;
    bool specialInUse;

    bool healthPotionButtonPressed;
    bool manaPotionButtonPressed;
    bool attackPotionButtonPressed;
    bool defensePotionButtonPressed;

    bool special1ButtonPressed;
    bool special2ButtonPressed;
    bool special3ButtonPressed;
    bool special4ButtonPressed;
    public String[] specialSkill = new string[3];

    // Use this for initialization
    void Start () {
        specialInUse = false;
        randomizeDone = false;
        doCountdown = false;
        actionDone = false;
        countdown = 0;
        attackButtonPressed = false;
        enemyAttacked = false;
	}
	
	// Update is called once per frame
	void Update () {
        enemy = GameObject.Find("Enemy");
        inBattle = cameras.GetComponent<CameraSwitch>().inBattle;

        if(inBattle)
        {
            if (enemy.GetComponent<Enemy>().health <= 0 && countdown == 0)
            {
                enemy.GetComponent<Enemy>().SetBattle(false);
                enemy.GetComponent<Enemy>().gameObject.SetActive(false);
                player.GetComponent<Player>().setMove(true);
            }
            if (!items.GetComponent<ItemMenu>().playerTurn && inBattle)
            {
                combat();
            }
            else if(items.GetComponent<ItemMenu>().playerTurn && inBattle)
            {
                buttons.SetActive(true);
                checkAttack();
                checkSpecial();
                checkPotions();
            }
        }
        else
        {
            items.GetComponent<ItemMenu>().playerTurn = true;
            player.GetComponent<Player>().health = 100;
            player.GetComponent<Player>().mana = 100;
            player.GetComponent<Player>().attackDamage = 20;
            player.GetComponent<Player>().defense = 0;
        }

        if (player.GetComponent<Player>().health <= 0)
        {
            cameras.GetComponent<CameraSwitch>().setInBattle(false);
            player.GetComponent<Player>().Die();
            gameOverUI.SetActive(true);
        }
    }

    private void checkSpecial()
    {
        if (special1ButtonPressed && items.GetComponent<ItemMenu>().playerTurn)
        {
            specialSkill = player.GetComponent<Player>().special1;
        }
        else if (special2ButtonPressed && items.GetComponent<ItemMenu>().playerTurn)
        {
            specialSkill = player.GetComponent<Player>().special2;
        }
        else if (special3ButtonPressed && items.GetComponent<ItemMenu>().playerTurn)
        {
            specialSkill = player.GetComponent<Player>().special3;
        }
        else if (special4ButtonPressed && items.GetComponent<ItemMenu>().playerTurn)
        {
            specialSkill = player.GetComponent<Player>().special4;
        }

        if((special1ButtonPressed || special2ButtonPressed || special3ButtonPressed || special4ButtonPressed) && items.GetComponent<ItemMenu>().playerTurn &&
            ((player.GetComponent<Player>().mana - int.Parse(specialSkill[2]) >= 0) || specialInUse))
        {
            specialInUse = true;
            buttons.GetComponent<BattleButtons>().disableMenus();
            battleLog.GetComponentInChildren<TextMeshProUGUI>().text = "Player uses " + specialSkill[0] + "!";
            useSpecialSkill();
        }
        else
        {
            specialInUse = false;
            special1ButtonPressed = false;
            special2ButtonPressed = false;
            special3ButtonPressed = false;
            special4ButtonPressed = false;
        }
    }

    private void useSpecialSkill()
    {
        buttons.SetActive(false);
        doCountdown = true;

        if (countdown >= 4)
        {
            doCountdown = false;
            actionDone = false;
            countdown = 0;
            battleLog.SetActive(false);
            special1ButtonPressed = false;
            special2ButtonPressed = false;
            special3ButtonPressed = false;
            special4ButtonPressed = false;
            items.GetComponent<ItemMenu>().playerTurn = false;
        }
        else if (countdown >= 3 && !actionDone)
        {
            buttons.GetComponent<BattleButtons>().useSpecialSkill();
            actionDone = true;
        }
        else if (countdown >= 1)
        {
            battleLog.SetActive(true);
        }

        if (doCountdown)
        {
            countdown = countdown + Time.deltaTime;
        }
    }

    private void checkAttack()
    {
        if (attackButtonPressed && items.GetComponent<ItemMenu>().playerTurn)
        {
            playerAttack();
        }
    }

    private void checkPotions()
    {
        if (healthPotionButtonPressed && items.GetComponent<ItemMenu>().playerTurn)
        {
            buttons.GetComponent<BattleButtons>().disableMenus();
            useHealthPotion();
        }
        else if (manaPotionButtonPressed && items.GetComponent<ItemMenu>().playerTurn)
        {
            buttons.GetComponent<BattleButtons>().disableMenus();
            useManaPotion();
        }
        else if (attackPotionButtonPressed && items.GetComponent<ItemMenu>().playerTurn)
        {
            buttons.GetComponent<BattleButtons>().disableMenus();
            useAttackPotion();
        }
        else if (defensePotionButtonPressed && items.GetComponent<ItemMenu>().playerTurn)
        {
            buttons.GetComponent<BattleButtons>().disableMenus();
            useDefensePotion();
        }
    }

    private void useHealthPotion()
    {
        buttons.SetActive(false);
        doCountdown = true;

        if (countdown >= 4)
        {
            doCountdown = false;
            actionDone = false;
            countdown = 0;
            battleLog.SetActive(false);
            healthPotionButtonPressed = false;
            items.GetComponent<ItemMenu>().playerTurn = false;
        }
        else if (countdown >= 3 && !actionDone)
        {
            items.GetComponent<ItemMenu>().useHealthPotion();
            actionDone = true;
        }
        else if (countdown >= 1)
        {
            battleLog.SetActive(true);
        }

        if (doCountdown)
        {
            countdown = countdown + Time.deltaTime;
        }
    }
    private void useManaPotion()
    {
        buttons.SetActive(false);
        doCountdown = true;

        if (countdown >= 4)
        {
            doCountdown = false;
            actionDone = false;
            countdown = 0;
            battleLog.SetActive(false);
            manaPotionButtonPressed = false;
            items.GetComponent<ItemMenu>().playerTurn = false;
        }
        else if (countdown >= 3 && !actionDone)
        {
            items.GetComponent<ItemMenu>().useManaPotion();
            actionDone = true;
        }
        else if (countdown >= 1)
        {
            battleLog.SetActive(true);
        }

        if (doCountdown)
        {
            countdown = countdown + Time.deltaTime;
        }
    }
    private void useAttackPotion()
    {
        buttons.SetActive(false);
        doCountdown = true;

        if (countdown >= 4)
        {
            doCountdown = false;
            actionDone = false;
            countdown = 0;
            battleLog.SetActive(false);
            attackPotionButtonPressed = false;
            items.GetComponent<ItemMenu>().playerTurn = false;
        }
        else if (countdown >= 3 && !actionDone)
        {
            items.GetComponent<ItemMenu>().useAttackPotion();
            actionDone = true;
        }
        else if (countdown >= 1)
        {
            battleLog.SetActive(true);
        }

        if (doCountdown)
        {
            countdown = countdown + Time.deltaTime;
        }
    }
    private void useDefensePotion()
    {
        buttons.SetActive(false);
        doCountdown = true;

        if (countdown >= 4)
        {
            doCountdown = false;
            actionDone = false;
            countdown = 0;
            battleLog.SetActive(false);
            defensePotionButtonPressed = false;
            items.GetComponent<ItemMenu>().playerTurn = false;
        }
        else if (countdown >= 3 && !actionDone)
        {
            items.GetComponent<ItemMenu>().useDefensePotion();
            actionDone = true;
        }
        else if (countdown >= 1)
        {
            battleLog.SetActive(true);
        }

        if (doCountdown)
        {
            countdown = countdown + Time.deltaTime;
        }
    }

    private void playerAttack()
    {
        buttons.SetActive(false);
        doCountdown = true;

        if (countdown >= 4)
        {
            doCountdown = false;
            actionDone = false;
            countdown = 0;
            battleLog.SetActive(false);
            attackButtonPressed = false;
            items.GetComponent<ItemMenu>().playerTurn = false;
        }
        else if (countdown >= 3 && !actionDone)
        {
            buttons.GetComponent<BattleButtons>().doAttack();
            actionDone = true;
        }
        else if (countdown >= 1)
        {
            battleLog.SetActive(true);
        }

        if(doCountdown)
        {
            countdown = countdown + Time.deltaTime;
        }
    }

    private void combat()
    {
        if(!items.GetComponent<ItemMenu>().playerTurn)
        {
            doCountdown = true;
            buttons.SetActive(false);

            if (countdown > 4)
            {
                doCountdown = false;
                items.GetComponent<ItemMenu>().playerTurn = true;
                countdown = 0;
                battleLog.SetActive(false);
                randomizeDone = false;
                enemyAttacked = false;
            }
            else if(countdown >= 3 && !enemyAttacked)
            {
                attackPlayer();
                enemyAttacked = true;
            }
            else if (countdown >= 1 && !randomizeDone)
            {
                battleLog.SetActive(true);
                enemyRandomizeAttack();
                randomizeDone = true;
                battleLog.GetComponentInChildren<TextMeshProUGUI>().text = "Enemy uses " + enemySkillName + "!";
            }

            if(doCountdown)
            {
                countdown = countdown + Time.deltaTime;
            }
        }
    }

    private void attackPlayer()
    {
        if(skill - player.GetComponent<Player>().defense > 0)
        {
            player.GetComponent<Player>().health = player.GetComponent<Player>().health - (skill - player.GetComponent<Player>().defense);
        }
    }

    private void enemyRandomizeAttack()
    {
        skill = UnityEngine.Random.Range(1, 5);

        switch (skill) {
            case 1:
                skill = enemy.GetComponent<Enemy>().skill1;
                enemySkillName = enemy.GetComponent<Enemy>().skill1Name;
                break;
            case 2:
                skill = enemy.GetComponent<Enemy>().skill2;
                enemySkillName = enemy.GetComponent<Enemy>().skill2Name;
                break;
            case 3:
                skill = enemy.GetComponent<Enemy>().skill3;
                enemySkillName = enemy.GetComponent<Enemy>().skill3Name;
                break;
            case 4:
                skill = enemy.GetComponent<Enemy>().skill4;
                enemySkillName = enemy.GetComponent<Enemy>().skill4Name;
                break;
        }
    }

    public void usedHealthPotion()
    {
        if(player.GetComponent<Player>().healtPotionCount>0)
        {
            battleLog.GetComponentInChildren<TextMeshProUGUI>().text = "Player uses Health Potion!";
            healthPotionButtonPressed = true;
        }
    }
    public void usedManaPotion()
    {
        if (player.GetComponent<Player>().manaPotionCount > 0)
        {
            battleLog.GetComponentInChildren<TextMeshProUGUI>().text = "Player uses Mana Potion!";
            manaPotionButtonPressed = true;
        }
    }
    public void usedAttackPotion()
    {
        if (player.GetComponent<Player>().attackPotionCount > 0)
        {
            battleLog.GetComponentInChildren<TextMeshProUGUI>().text = "Player uses Attack Potion!";
            attackPotionButtonPressed = true;
        }
    }
    public void usedDefensePotion()
    {
        if (player.GetComponent<Player>().defensePotionCount > 0)
        {
            battleLog.GetComponentInChildren<TextMeshProUGUI>().text = "Player uses Defense Potion!";
            defensePotionButtonPressed = true;
        }
    }
    public void playerUsedAttack()
    {
        attackButtonPressed = true;
        battleLog.GetComponentInChildren<TextMeshProUGUI>().text = "Player attacks!";
    }

    public void usedSpecial1()
    {
        special1ButtonPressed = true;
    }
    public void usedSpecial2()
    {
        special2ButtonPressed = true;
    }
    public void usedSpecial3()
    {
        special3ButtonPressed = true;
    }
    public void usedSpecial4()
    {
        special4ButtonPressed = true;
    }
}
