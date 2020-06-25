//Script by Evan Waters 1017144

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
   public void PlayButt()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
