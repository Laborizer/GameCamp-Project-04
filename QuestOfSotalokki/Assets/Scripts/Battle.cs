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
    public GameObject skillAnimations;

    public bool inBattle;
    public GameObject cameras;
    public GameObject items;
    public GameObject buttons;
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    public GameObject EnemyELP;
    public GameObject EnemyGIF;
    public GameObject EnemySnake;
    public GameObject FireBoss;
    public GameObject IceBoss;
    public GameObject ThunderBoss;
    public GameObject ShotgunBoss;
    public GameObject FinalBoss;

    String enemySkillName;
    bool doCountdown;
    bool actionDone;
    bool attackButtonPressed;
    bool enemyAttacked;
    int skill;
    float countdown;
    bool randomizeDone;
    bool specialInUse;
    bool skillAnimationOn;
    bool animationDone;

    bool healthPotionButtonPressed;
    bool manaPotionButtonPressed;
    bool attackPotionButtonPressed;
    bool defensePotionButtonPressed;

    bool special1ButtonPressed;
    bool special2ButtonPressed;
    bool special3ButtonPressed;
    bool special4ButtonPressed;
    public String[] specialSkill = new string[3];

    bool GameWin;

    // Use this for initialization
    void Start () {
        skillAnimationOn = skillAnimations.GetComponent<SkillAnimations>().skillAnimationOn;
        animationDone = skillAnimations.GetComponent<SkillAnimations>().animationDone;
        specialInUse = false;
        randomizeDone = false;
        doCountdown = false;
        actionDone = false;
        countdown = 0;
        attackButtonPressed = false;
        enemyAttacked = false;
        GameWin = false;
    }
	
	// Update is called once per frame
	void Update () {
        skillAnimationOn = skillAnimations.GetComponent<SkillAnimations>().skillAnimationOn;
        animationDone = skillAnimations.GetComponent<SkillAnimations>().animationDone;

        enemy = GameObject.Find("Enemy");
        inBattle = cameras.GetComponent<CameraSwitch>().inBattle;
        if (inBattle)
        {
            player.GetComponent<Player>().setMove(false);
            if (enemy.GetComponent<Enemy>().getRealName() == "EnemyELP")
            {
                EnemyELP.gameObject.SetActive(true);
                EnemySnake.gameObject.SetActive(false);
                EnemyGIF.gameObject.SetActive(false);
                FireBoss.gameObject.SetActive(false);
                IceBoss.gameObject.SetActive(false);
                ThunderBoss.gameObject.SetActive(false);
                ShotgunBoss.gameObject.SetActive(false);
                FinalBoss.gameObject.SetActive(false);
            } else if (enemy.GetComponent<Enemy>().getRealName() == "EnemyGIF")
            {
                EnemyELP.gameObject.SetActive(false);
                EnemySnake.gameObject.SetActive(false);
                EnemyGIF.gameObject.SetActive(true);
                FireBoss.gameObject.SetActive(false);
                IceBoss.gameObject.SetActive(false);
                ThunderBoss.gameObject.SetActive(false);
                ShotgunBoss.gameObject.SetActive(false);
                FinalBoss.gameObject.SetActive(false);
            } else if (enemy.GetComponent<Enemy>().getRealName() == "FinalBoss")
            {
                EnemyELP.gameObject.SetActive(false);
                EnemySnake.gameObject.SetActive(false);
                EnemyGIF.gameObject.SetActive(false);
                FireBoss.gameObject.SetActive(false);
                IceBoss.gameObject.SetActive(false);
                ThunderBoss.gameObject.SetActive(false);
                ShotgunBoss.gameObject.SetActive(false);
                FinalBoss.gameObject.SetActive(true);
            } else if (enemy.GetComponent<Enemy>().getRealName() == "FireBoss")
            {
                EnemyELP.gameObject.SetActive(false);
                EnemySnake.gameObject.SetActive(false);
                EnemyGIF.gameObject.SetActive(false);
                FireBoss.gameObject.SetActive(true);
                IceBoss.gameObject.SetActive(false);
                ThunderBoss.gameObject.SetActive(false);
                ShotgunBoss.gameObject.SetActive(false);
                FinalBoss.gameObject.SetActive(false);
            } else if (enemy.GetComponent<Enemy>().getRealName() == "IceBoss")
            {
                EnemyELP.gameObject.SetActive(false);
                EnemySnake.gameObject.SetActive(false);
                EnemyGIF.gameObject.SetActive(false);
                FireBoss.gameObject.SetActive(false);
                IceBoss.gameObject.SetActive(true);
                ThunderBoss.gameObject.SetActive(false);
                ShotgunBoss.gameObject.SetActive(false);
                FinalBoss.gameObject.SetActive(false);
            } else if (enemy.GetComponent<Enemy>().getRealName() == "ThunderBoss")
            {
                EnemyELP.gameObject.SetActive(false);
                EnemySnake.gameObject.SetActive(false);
                EnemyGIF.gameObject.SetActive(false);
                FireBoss.gameObject.SetActive(false);
                IceBoss.gameObject.SetActive(false);
                ThunderBoss.gameObject.SetActive(true);
                ShotgunBoss.gameObject.SetActive(false);
                FinalBoss.gameObject.SetActive(false);
            } else if (enemy.GetComponent<Enemy>().getRealName() == "ShotgunBoss")
            {
                EnemyELP.gameObject.SetActive(false);
                EnemySnake.gameObject.SetActive(false);
                EnemyGIF.gameObject.SetActive(false);
                FireBoss.gameObject.SetActive(false);
                IceBoss.gameObject.SetActive(false);
                ThunderBoss.gameObject.SetActive(false);
                ShotgunBoss.gameObject.SetActive(true);
                FinalBoss.gameObject.SetActive(false);
            } else if (enemy.GetComponent<Enemy>().getRealName() == "EnemySnake")
            {
                EnemyELP.gameObject.SetActive(false);
                EnemySnake.gameObject.SetActive(true);
                EnemyGIF.gameObject.SetActive(false);
                FireBoss.gameObject.SetActive(false);
                IceBoss.gameObject.SetActive(false);
                ThunderBoss.gameObject.SetActive(false);
                ShotgunBoss.gameObject.SetActive(false);
                FinalBoss.gameObject.SetActive(false);
            }

            Debug.Log("asd" + enemy.GetComponent<Enemy>().getRealName());

            if (enemy.GetComponent<Enemy>().health <= 0 && countdown == 0)
            {
                if (enemy.GetComponent<Enemy>().getRealName() == "FinalBoss")
                {
                    gameWinUI.gameObject.SetActive(true);
                    GameWin = true;
                }
                enemy.GetComponent<Enemy>().SetBattle(false);
                player.GetComponent<Player>().setBattle(false);
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
            player.GetComponent<Player>().damageMultiplier = 1;
            player.GetComponent<Player>().defense = 0;
        }

        if (player.GetComponent<Player>().health <= 0)
        {
            cameras.GetComponent<CameraSwitch>().setInBattle(false);
            player.GetComponent<Player>().Die();
            gameOverUI.SetActive(true);
        }
        if (GameWin)
        {
            player.GetComponent<Player>().setMove(false);
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
        if (skillAnimationOn)
        {
            doCountdown = false;
        }
        else
        {
            doCountdown = true;
        }

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
            skillAnimations.GetComponent<SkillAnimations>().animationDone = false;
        }
        else if (countdown >= 3 && !actionDone)
        {
            buttons.GetComponent<BattleButtons>().useSpecialSkill();
            actionDone = true;
        }
        else if (countdown >= 2 && !animationDone)
        {
            if (specialSkill[0].Equals("Fire"))
            {
                skillAnimations.GetComponent<SkillAnimations>().fireOnEnemy();
            }
            else if (specialSkill[0].Equals("Thunder"))
            {
                skillAnimations.GetComponent<SkillAnimations>().thunderOnEnemy();
            }
            else if (specialSkill[0].Equals("Ice"))
            {
                skillAnimations.GetComponent<SkillAnimations>().iceOnEnemy();
            }
            else if (specialSkill[0].Equals("Shotgun"))
            {
                skillAnimations.GetComponent<SkillAnimations>().shotgunOnEnemy();
            }
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
        if (skillAnimationOn)
        {
            doCountdown = false;
        }
        else
        {
            doCountdown = true;
        }

        if (countdown >= 4)
        {
            doCountdown = false;
            actionDone = false;
            countdown = 0;
            battleLog.SetActive(false);
            attackButtonPressed = false;
            items.GetComponent<ItemMenu>().playerTurn = false;
            skillAnimations.GetComponent<SkillAnimations>().animationDone = false;
        }
        else if (countdown >= 3 && !actionDone)
        {
            buttons.GetComponent<BattleButtons>().doAttack();
            actionDone = true;
        }
        else if(countdown >= 2 && !animationDone)
        {
            skillAnimations.GetComponent<SkillAnimations>().hitOnEnemy();
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
            if (skillAnimationOn)
            {
                doCountdown = false;
            }
            else
            {
                doCountdown = true;
            }
            buttons.SetActive(false);

            if (countdown > 4)
            {
                doCountdown = false;
                items.GetComponent<ItemMenu>().playerTurn = true;
                skillAnimations.GetComponent<SkillAnimations>().animationDone = false;
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
            else if(countdown >= 2 && !animationDone)
            {
                if(enemySkillName.Equals("Shotgun"))
                {
                    skillAnimations.GetComponent<SkillAnimations>().shotgunOnPlayer();
                }
                else if (enemySkillName.Equals("Fire"))
                {
                    skillAnimations.GetComponent<SkillAnimations>().fireOnPlayer();
                }
                else if (enemySkillName.Equals("Thunder"))
                {
                    skillAnimations.GetComponent<SkillAnimations>().thunderOnPlayer();
                }
                else if (enemySkillName.Equals("Ice"))
                {
                    skillAnimations.GetComponent<SkillAnimations>().iceOnPlayer();
                }
                else
                {
                    skillAnimations.GetComponent<SkillAnimations>().hitOnPlayer();
                }
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
        if(player.GetComponent<Player>().special1[0].Length > 0)
        {
            special1ButtonPressed = true;
        }
    }
    public void usedSpecial2()
    {
        if (player.GetComponent<Player>().special2[0].Length > 0)
        {
            special2ButtonPressed = true;
        }
    }
    public void usedSpecial3()
    {
        if (player.GetComponent<Player>().special3[0].Length > 0)
        {
            special3ButtonPressed = true;
        }
    }
    public void usedSpecial4()
    {
        if (player.GetComponent<Player>().special4[0].Length > 0)
        {
            special4ButtonPressed = true;
        }
    }
}
