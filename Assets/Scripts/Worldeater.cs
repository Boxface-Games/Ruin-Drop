using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worldeater : MonoBehaviour
{
    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Debug.Log("alldelete");
    }

}
