using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public PlayerScript playerScript;
    public AudioSource hitSE;
    public AudioSource gemSE;


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            playerScript.TakeDamage(25);
            hitSE.Play();
        }

        if (other.tag == "gem")
        {
            playerScript.scoreAdd(100);
            gemSE.Play();
            Destroy(other.gameObject);
            Debug.Log("scoreAdded!");
        }
    }

 }
