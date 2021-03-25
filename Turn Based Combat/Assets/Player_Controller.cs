using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Enemy_RNG enemy_RNG;
    public Player_RNG player_RNG;

    public int playerCurrentHealth;
    public int playerMaxHealth;

    public int playerHealed =0;
   
   

    //THIS WILL BE A RANDOMLY GENERATED NUMBER 
    public int enemyDamageGiven;

   


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void playerTakenDamage()
    {
        enemyDamageGiven = enemy_RNG.enemyAttackHealStatNumber;
        playerCurrentHealth = playerCurrentHealth - enemyDamageGiven ;
       // Debug.Log("player " + playerCurrentHealth);
    }

    public void playerHealedUp()
    {
        playerCurrentHealth = playerCurrentHealth + playerHealed;
        if(playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
    }


}
