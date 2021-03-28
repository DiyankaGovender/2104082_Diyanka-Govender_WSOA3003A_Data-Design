using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum GameState
{ 
    gameStart,


    battleSetup,

    playerTurn,
    enemyTurn,

    playerWins,
    playerLost,


}

public class BattleState : MonoBehaviour
{
    public GameState gameState;

    public GameObject square;
   

    public Enemy_AI enemy_AI;
    public Player_Controller player_Controller;
    public Enemy_RNG enemy_RNG;
    public Player_RNG player_RNG;
    

    //PLAYER AND ENEMY SPRITES
    public GameObject player;
    public GameObject enemy;

    //MAIN TEXT BOX AND OTHER TEXT BOX
    public TextMeshProUGUI maintextBox;
    public TextMeshProUGUI pickNumber;
    
    //ENEMY AND PLAYER HEALTH
    public TextMeshProUGUI playerUI;
    public TextMeshProUGUI playerUI2;
    public TextMeshProUGUI enemyUI;
    public TextMeshProUGUI enemyUI2;

    //BUTTONS
    public GameObject startButton;
    

    public GameObject playerAttackButton;
    public GameObject playerHealButton;


    void Start()
    {
        //Debug.Log("Start State"); 

        gameState = GameState.gameStart;

        square.SetActive(false);
        player.SetActive(false);
        playerUI.enabled = false;
        playerUI2.enabled = false;

        enemy.SetActive(false);
        enemyUI.enabled = false;
        enemyUI2.enabled = false;


        maintextBox.enabled = false;
        pickNumber.enabled = false;

        startButton.SetActive(true);
        
        playerAttackButton.SetActive(false);
        playerHealButton.SetActive(false);
    
      
       
       
    
    }


    public void onStartButtonState()
    {
        if (gameState == GameState.gameStart)
        {
            //Debug.Log("Ended Start State");

            startButton.SetActive(false);
            gameState = GameState.battleSetup;
            square.SetActive(true);
            battleSetupState();

        }
     
    }



    public void battleSetupState()
    {
        //Debug.Log("Battle setup");

        player.SetActive(true);
        playerUI.enabled = true;
        playerUI2.enabled = true;

        enemy.SetActive(true);
        enemyUI.enabled = true;
        enemyUI2.enabled = true;

        maintextBox.enabled = true;
        maintextBox.text = "It is now your turn, pick a number!";

        pickNumber.enabled = true;

        gameState = GameState.playerTurn;
        StartCoroutine(playerTurnState());


        //PLAYER RNG START
        player_RNG.activateRNG();
        player_RNG.activateNumber();
        
    }

    //PLAYER TURN STATE
    IEnumerator playerTurnState()
    {
        yield return new WaitForSeconds(2f);
        maintextBox.text = "It is now your turn, pick a card!";
        pickNumber.enabled = true;

        yield return new WaitForSeconds(4f);
        pickNumber.enabled = false;
        yield return new WaitForSeconds(1f);
        maintextBox.text = "What do you want to do?";
        playerAttackButton.SetActive(true);
        playerHealButton.SetActive(true);


        //Debug.Log("Player Turn");

       
       
    }


    //PLAYER ATTACK
    public void onPlayerAttackButton()
    {
        if (gameState != GameState.playerTurn)
            return;
        else StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        yield return new WaitForSeconds(2);

        //Debug.Log("Player Attacks");

        //UI UPDATED 
        maintextBox.text = "Player ATTACKS";
        
        yield return new WaitForSeconds(2);
        
        //ENEMY DAMAGED 
        enemy_AI.enemyTakenDamage();

        //UI UPDATED
        maintextBox.text = "Enemy has taken " + enemy_AI.playerDamageAttackGiven + " DAMAGE";
        enemyUI.text = enemy_AI.enemyCurrentHealth + "/" + enemy_AI.enemyMaxHealth;
      
        
        //HAS ENEMY BEEN KILLED?
        if(enemy_AI.enemyCurrentHealth <= 0)
        {
            //Debug.Log("Dead enemy");
            enemy_AI.enemyCurrentHealth = 0;
            gameState = GameState.playerWins;
            endState();
        }
        else
        {
            Debug.Log("Enemy Turn State");

            gameState = GameState.enemyTurn;
            StartCoroutine(enemyTurnState());

            enemy_RNG.generateRNGAttackHealStateNumber();
            enemy_RNG.generateEnemyCardPosition();
            enemy_RNG.generateEnemyAttackHealStatNumber();
        }
        
    }



    //PLAYER HEAL
    public void onPlayerHealButton()
    {
        if (gameState != GameState.playerTurn)
            return;
        else StartCoroutine(PlayerHeal());
    }


    IEnumerator PlayerHeal()
    {
        yield return new WaitForSeconds(2);

        //Debug.Log("Player Heals");

        //UI UPDATED 
        maintextBox.text = "Player HEALS";

        yield return new WaitForSeconds(2);

        //PLAYER HEALED
        player_Controller.playerHealedUp();

        //UI UPDATED
        maintextBox.text = "Player has HEALED by " + player_Controller.playerHealed + " HP";
        playerUI.text = player_Controller.playerCurrentHealth + "/" + player_Controller.playerMaxHealth;


        //HAS ENEMY BEEN KILLED?
        if (enemy_AI.enemyCurrentHealth <= 0)
        {
            //Debug.Log("Dead enemy");
            enemy_AI.enemyCurrentHealth = 0;
            gameState = GameState.playerWins;
            endState();
        }
        else
        {
            //Debug.Log("Enemy Turn State");

            gameState = GameState.enemyTurn;
            StartCoroutine(enemyTurnState());

            enemy_RNG.generateRNGAttackHealStateNumber();
            enemy_RNG.generateEnemyCardPosition();
            enemy_RNG.generateEnemyAttackHealStatNumber();

        }

    }



    //ENEMY TURN STATE 
    IEnumerator enemyTurnState()
    {
        enemy_RNG.generateRNGAttackHealStateNumber();
        enemy_RNG.generateEnemyCardPosition();
        enemy_RNG.generateEnemyAttackHealStatNumber();
        

        //PLAYER BUTTONS DISABLED
        playerAttackButton.SetActive(false);
        playerHealButton.SetActive(false);
       

        yield return new WaitForSeconds(2);
        maintextBox.text = "Enemy Turn"; 

        yield return new WaitForSeconds(2);

        //ENEMY ATTACK
        if (enemy_RNG.enemyRNGAttackHealStateNumber == 1)
        {
            enemy_RNG.generateEnemyAttackHealStatNumber();
            //UI UPDATED
            maintextBox.text = "Enemy ATTACKS";
            Debug.Log("Enemy Attacks");

            yield return new WaitForSeconds(2);
            //PLAYER DAMAGED 
            player_Controller.playerTakenDamage();

            //UI UPDATED 
            maintextBox.text = "Player has taken " + player_Controller.enemyDamageGiven + " DAMAGE";
            playerUI.text = player_Controller.playerCurrentHealth + "/" + player_Controller.playerMaxHealth;


            //IS PLAYER DEAD?
            if (player_Controller.playerCurrentHealth <= 0)
            {
                player_Controller.playerCurrentHealth = 0;
                //Debug.Log("Player Dead");
                gameState = GameState.playerLost;
                endState();
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                gameState = GameState.playerTurn;
                StartCoroutine(playerTurnState());
            }




        }
        //ENEMY HEALS
        if (enemy_RNG.enemyRNGAttackHealStateNumber == 2)
        {
            enemy_RNG.generateEnemyAttackHealStatNumber();

            //UI UPDATED
            maintextBox.text = "Enemy HEALS";
            Debug.Log("Enemy HEALS");

            yield return new WaitForSeconds(2);
            //ENEMY HEALS 
            enemy_AI.enemyHealedUp();

            //UI UPDATED 
            maintextBox.text = "Enemy has HEALED by " + enemy_AI.enemyHealed + " HP";
            enemyUI.text = enemy_AI.enemyCurrentHealth + "/" + enemy_AI.enemyMaxHealth;


            //IS PLAYER DEAD?
            if (player_Controller.playerCurrentHealth <= 0)
            {
                //Debug.Log("Player Dead");
                gameState = GameState.playerLost;
                endState();
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
                gameState = GameState.playerTurn;
                StartCoroutine(playerTurnState());
            }
        }


    }

    void endState()
    {
        //Debug.Log("end");
        if(gameState == GameState.playerWins)
        {
            maintextBox.text = "Player WINS!";

            playerAttackButton.SetActive(false);
            playerHealButton.SetActive(false);
        }

        //Debug.Log("end");
        if (gameState == GameState.playerLost)
        {
            maintextBox.text = "Player LOSES";

            playerAttackButton.SetActive(false);
            playerHealButton.SetActive(false);
        }
      
    }


}
