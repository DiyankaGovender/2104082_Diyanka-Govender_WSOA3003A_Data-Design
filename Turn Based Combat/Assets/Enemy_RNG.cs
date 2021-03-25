using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_RNG : MonoBehaviour
{
    public Player_RNG player_RNG;

    public int enemyRNGAttackHealStateNumber;


    public int enemyCardPosition;
    public int enemyAttackHealStatNumber;

    public bool enemyChoseCard1;
    public bool enemyChoseCard2;
    public bool enemyChoseCard3;
    public bool enemyChoseCard4;
    public bool enemyChoseCard5;
    public bool enemyChoseCard6;

    void Start()
    {
        //enemyCardPosition = 1;
        enemyRNGAttackHealStateNumber = 1;

        enemyChoseCard1 = false;
        enemyChoseCard2 = false;
        enemyChoseCard3 = false;
        enemyChoseCard4 = false;
        enemyChoseCard5 = false;
        enemyChoseCard6 = false;
    }

    
    void Update()
    {
        
    }

    public void generateRNGAttackHealStateNumber()
    {
     
        enemyRNGAttackHealStateNumber = Random.Range(1, 3);
    }

    public void generateEnemyCardPosition()
    {
        Debug.Log("ENEMY CARD POSITION " + enemyCardPosition);

        enemyCardPosition = Random.Range(1, 7);
        if (enemyCardPosition == 7)
        {
            enemyCardPosition = 6;
        }

        if (enemyCardPosition == 0)
        {
            enemyCardPosition = 1;
        }


    }

    public void generateEnemyAttackHealStatNumber()
    {
        Debug.Log("ENEMY ATTACK/HEAL STAT NUMBER: " + enemyAttackHealStatNumber);
        if (enemyCardPosition == 1)
        {
            player_RNG.button1.GetComponent<Button>().interactable = false;
            enemyAttackHealStatNumber = player_RNG.randomNumber1;
        }

        if (enemyCardPosition == 2)
        {
            player_RNG.button2.GetComponent<Button>().interactable = false;
            enemyAttackHealStatNumber = player_RNG.randomNumber2;
        }

        if (enemyCardPosition == 3)
        {
            player_RNG.button3.GetComponent<Button>().interactable = false;
            enemyAttackHealStatNumber = player_RNG.randomNumber3;
        }

        if (enemyCardPosition == 4)
        {
            player_RNG.button4.GetComponent<Button>().interactable = false;
            enemyAttackHealStatNumber = player_RNG.randomNumber4;
        }


        if (enemyCardPosition == 5)
        {
            player_RNG.button5.GetComponent<Button>().interactable = false;
            enemyAttackHealStatNumber = player_RNG.randomNumber5;
        }

        if (enemyCardPosition == 6)
        {
            player_RNG.button6.GetComponent<Button>().interactable = false;
            enemyAttackHealStatNumber = player_RNG.randomNumber6;
        }
    }

}
