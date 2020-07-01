using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
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

    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Moves the GameObject using it's transform.
        rb.isKinematic = true;


        //level text starts at 1
        SetLevelText(1);
    }

    // Update is called once per frame

    public void FixedUpdate()
    {
        rb.MovePosition(transform.position + -transform.up * camSpeed * Time.fixedDeltaTime);

    }

    void Update()
    {
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
