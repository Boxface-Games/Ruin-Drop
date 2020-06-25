using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrip : MonoBehaviour
{
    [Header("Player Swap")]
    public GameObject leftC;
    public GameObject rightC;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
            Debug.Log("test");
                if (leftC.activeInHierarchy == true)
                {
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
}
