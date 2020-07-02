using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public PlayerScript playerScript;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            playerScript.TakeDamage(25);
        }

        if (other.tag == "gem")
        {
            //playerScript.scoreAdd(100);
            Destroy(other.gameObject);
            Debug.Log("scoreAdded!");
        }
    }

 }
