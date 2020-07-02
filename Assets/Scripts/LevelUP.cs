using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUP : MonoBehaviour
{
    public PlayerScript playerScript;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "levelup")
        {
            playerScript.camSpeed++;
            playerScript.levelUP(1);
        }
    }
}
