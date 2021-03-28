using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player_RNG : MonoBehaviour
{
    public Enemy_AI enemy_AI;
    public Player_Controller player_Controller;
    public BattleState battleState;

    public int randomButtonClickAmount;

    public TextMeshProUGUI number1;
    public TextMeshProUGUI number2;
    public TextMeshProUGUI number3;
    public TextMeshProUGUI number4;
    public TextMeshProUGUI number5;
    public TextMeshProUGUI number6;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;

    
    public int randomNumber1;
    public int randomNumber2;
    public int randomNumber3;
    public int randomNumber4;
    public int randomNumber5;
    public int randomNumber6;

    public GameObject randomButton;

    public void Start()
    {
        randomButton.SetActive(false);

        number1.enabled = false;
        number2.enabled = false;
        number3.enabled = false;
        number4.enabled = false;
        number5.enabled = false;
        number6.enabled = false;


        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);
        button5.SetActive(false);
        button6.SetActive(false);

    }

   
    //IF PLAYER CHOSE BUTTON 1
    public void clicked1()
    {

        if (battleState.playerAttackButton)
        {
            enemy_AI.playerDamageAttackGiven = randomNumber1;
            button1.GetComponent<Button>().interactable = false;

        }

        if (battleState.playerHealButton)
        {
            player_Controller.playerHealed = randomNumber1;
            button1.GetComponent<Button>().interactable = false;
        }

   
    }


    //IF PLAYER CHOSE BUTTON 2
    public void clicked2()
    {

        if (battleState.playerAttackButton)
        {
            enemy_AI.playerDamageAttackGiven = randomNumber2;

            button2.GetComponent<Button>().interactable = false;
        }

        if (battleState.playerHealButton)
        {
            player_Controller.playerHealed = randomNumber2;

            button2.GetComponent<Button>().interactable = false;
        }


    }


    //IF PLAYER CHOSE BUTTON 3
    public void clicked3()
    {

        if (battleState.playerAttackButton)
        {
            enemy_AI.playerDamageAttackGiven = randomNumber3;

            button3.GetComponent<Button>().interactable = false;
        }

        if (battleState.playerHealButton)
        {
            player_Controller.playerHealed = randomNumber3;

            button3.GetComponent<Button>().interactable = false;
        }


    }

    //IF PLAYER CHOSE BUTTON 4
    public void clicked4()
    {

        if (battleState.playerAttackButton)
        {
            enemy_AI.playerDamageAttackGiven = randomNumber4;

            button4.GetComponent<Button>().interactable = false;
        }

        if (battleState.playerHealButton)
        {
            player_Controller.playerHealed = randomNumber4;

            button4.GetComponent<Button>().interactable = false;
        }


    }



    //IF PLAYER CHOSE BUTTON 5
    public void clicked5()
    {

        if (battleState.playerAttackButton)
        {
            enemy_AI.playerDamageAttackGiven = randomNumber5;

            button5.GetComponent<Button>().interactable = false;
        }

        if (battleState.playerHealButton)
        {
            player_Controller.playerHealed = randomNumber5;

            button5.GetComponent<Button>().interactable = false;
        }


    }

    //IF PLAYER CHOSE BUTTON 6
    public void clicked6()
    {

        if (battleState.playerAttackButton)
        {
            enemy_AI.playerDamageAttackGiven = randomNumber6;

            button6.GetComponent<Button>().interactable = false;
        }

        if (battleState.playerHealButton)
        {
            player_Controller.playerHealed = randomNumber6;

            button6.GetComponent<Button>().interactable = false;
        }


    }

    public void activateRNG()
    {
        randomButton.SetActive(true);

        number1.enabled = true;
        number2.enabled = true;
        number3.enabled = true;
        number4.enabled = true;
        number5.enabled = true;
        number6.enabled = true;


        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
        button5.SetActive(true);
        button6.SetActive(true);

    }

    public void activateNumber()
    {
        number1RNG();
        number2RNG();
        number3RNG();
        number4RNG();
        number5RNG();
        number6RNG();

    }

    public void randomiseNumbers()
    {
        number1RNG();
        button1.GetComponent<Button>().interactable = true;
        
        number2RNG();
        button2.GetComponent<Button>().interactable = true;

        number3RNG();
        button3.GetComponent<Button>().interactable = true;

        number4RNG();
        button4.GetComponent<Button>().interactable = true;

        number5RNG();
        button5.GetComponent<Button>().interactable = true;

        number6RNG();
        button6.GetComponent<Button>().interactable = true;
    }



    public void number1RNG()
    {
        randomNumber1 = Random.Range(1, 11);
        number1.text = randomNumber1.ToString();
    }

    public void number2RNG()
    {
        randomNumber2 = Random.Range(1, 11);
        number2.text = randomNumber2.ToString();
    }


    public void number3RNG()
    {
        randomNumber3 = Random.Range(1, 11);
        number3.text = randomNumber3.ToString();
    }


    public void number4RNG()
    {
        randomNumber4 = Random.Range(1, 11);
        number4.text = randomNumber4.ToString();
    }

    public void number5RNG()
    {
        randomNumber5 = Random.Range(1, 11);
        number5.text = randomNumber5.ToString();
    }

    public void number6RNG()
    {
        randomNumber6 = Random.Range(1, 11);
        number6.text = randomNumber6.ToString();
    }
}
