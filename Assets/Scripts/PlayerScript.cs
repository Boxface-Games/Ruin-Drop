using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [Header("RigidBody")]
    public Rigidbody rb;

    [Header("Player Swap")]
    public GameObject leftC;
    public GameObject rightC;

    [Header("Level")]
    public float camSpeed;
    public Text levelText;
    public int level;
    public float jumpTime;

    [Header("Health")]
    public Image HPBar;
    public float Health;

    [Header("Score")]
    public int score;
    public Text ScoreText;
    public float timer;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Moves the GameObject using it's transform.
        rb.isKinematic = true;

        level = 1;
    }

    void Update()
    {
        //constant level update
        levelText.text = level.ToString();

        //Constant score update
        ScoreText.text = score.ToString();

        //timer for scoring
        timer += Time.deltaTime;

        //scoretimer function
        ScoreTimer();
                                 
        //controller input
        ControllerInputs();

        //health checker
        CheckIfAlive();        

        //health bar
        HPBar.fillAmount = Health / 100;

        //jumpTime -= Time.deltaTime;   

        //screen transform
        transform.Translate(Vector2.down * camSpeed * Time.deltaTime, Camera.main.transform);
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

    public void ScoreTimer ()
    {
        if (timer > 1f)
        {
            score += 10;

            ScoreText.text = score.ToString();

            //Reset the timer to 0.
            timer = 0;
        }
    }

    public void levelUP (int levelToAdd)
    {
        level += levelToAdd;
    }

    public void scoreAdd (int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void TakeDamage (int damageToTake)
    {
        Health -= damageToTake;
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
        if (PlayerPrefs.GetInt("Highscore") < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
        }

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);

        //code here for when player dies
    }

}
