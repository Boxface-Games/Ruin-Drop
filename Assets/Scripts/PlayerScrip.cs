using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScrip : MonoBehaviour
{
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
        //level text starts at 1
        SetLevelText(1);
    }

    // Update is called once per frame
    void Update()
    {
        jumpTime -= Time.deltaTime;

        //camera transform. constantly moving down with camSpeed to adjust speed per lvl
        transform.Translate(Vector2.down * camSpeed * Time.deltaTime, Camera.main.transform);

        //health stuff
        HPBar.fillAmount = Health / 100;
            //NOTES:
               //if collision.tag "player" collides with collision.tag "enemy"
              // -25 Health
             //if Health <= 0
            //pause, show game over text, save score, go to main menu

        //tap controls
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

    public void SetLevelText(int levelNum)
    {
        this.levelNum.text = " " + levelNum;
    }

}
