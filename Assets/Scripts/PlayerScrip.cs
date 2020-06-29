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

    public void Start()
    {
        SetLevelText(1);
    }

    // Update is called once per frame
    void Update()
    {

        //camera transform
        transform.Translate(Vector2.down * camSpeed * Time.deltaTime, Camera.main.transform);

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
                Debug.Log("test2");
            }           

                else
                {
                    rightC.SetActive(false);
                    leftC.SetActive(true);
                Debug.Log("Else");
                }
            }
        }
    }

    public void SetLevelText(int levelNum)
    {
        this.levelNum.text = " " + levelNum;
    }

}
