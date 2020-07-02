﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [Header("Rigidbody")]
    public Rigidbody rb;

    [Header("Player Swap")]
    public GameObject leftC;
    public GameObject rightC;

    [Header("Level")]
    public float camSpeed;
    public Text levelNum;
    public float jumpTime;

    [Header("Health")]
    public Image HPBar;
    public float Health;

<<<<<<< HEAD
    //Making Variables for the scoring system

    public Text ScoreText;
    private float time;
    public int score;
=======
    [Header("Score")]
    public float scoreFloat;
>>>>>>> bef27af2c16ed798593d21d5e0d468ed4ab98629

    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Moves the GameObject using it's transform.
        rb.isKinematic = true;


        //level text starts at 1
        SetLevelText(1);
    }

    void Update()
    {
        transform.Translate(Vector2.down * camSpeed * Time.deltaTime, Camera.main.transform);

        //controller input
        ControllerInputs();

        //health checker
        CheckIfAlive();        

        //health bar
        HPBar.fillAmount = Health / 100;

        //jumpTime -= Time.deltaTime;        

        //Scoring Set up

        time += Time.deltaTime;

        if (time > 10f)
        {
            score += 100;

            //Updating the text if the score changes

            ScoreText.text = score.ToString();

            //Resetting the Time in order to Repeat

            time = 0;
        }
    }

    //controller
    public void ControllerInputs ()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Debug.Log("test");
                if (leftC.activeInHierarchy == true)
                {
                    //NOTE:add wait 0.2f and animation

                    rightC.SetActive(true);
                    leftC.SetActive(false);
                }

                else
                {
                    rightC.SetActive(false);
                    leftC.SetActive(true);
                }
            }
        }
    }

    public void scoreAdd (int scoreToAdd)
    {
        scoreFloat += scoreToAdd;
    }

    public void TakeDamage (int damageToTake)
    {
        Health -= damageToTake;
    }

    public void SetLevelText(int levelNum)
    {
        this.levelNum.text = " " + levelNum;
    }

    public void CheckIfAlive ()
    {
        if (Health <= 0)
        {
            PlayerHasDied();
        }
    }

    public void PlayerHasDied ()
    {
        //code here for when player dies
    }

}
