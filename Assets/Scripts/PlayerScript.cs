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
    public Text levelNum;
    public int levelNumber;
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
    }

    void Update()
    {
        transform.Translate(Vector2.down * camSpeed * Time.deltaTime, Camera.main.transform);

        timer += Time.deltaTime;

        if(timer > 5f)
        {
            score += 5;

            ScoreText.text = score.ToString();

            //Reset the timer to 0.
            timer = 0;
        }
                          
        //controller input
        ControllerInputs();

        //health checker
        CheckIfAlive();        

        //health bar
        HPBar.fillAmount = Health / 100;

        //jumpTime -= Time.deltaTime;        
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
        score += scoreToAdd;
    }

    public void TakeDamage (int damageToTake)
    {
        Health -= damageToTake;
    }

    public void SetLevelText()
    {
        this.levelNum.text = " " + levelNumber;
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
