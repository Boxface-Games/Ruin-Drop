using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worldeater : MonoBehaviour
{
    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        //Destroy(gameObject);
        Debug.Log("alldelete");

        //  \* if (collision.gameObject.tag == "enemy")
        //    Destroy (gameObject);
        //    Debug.Log("spikedead");

        //    if (collision.gameObject.tag == "wall")
        //    Destroy(gameObject);
        //    Debug.Log("walldead");
        //
    }

}
