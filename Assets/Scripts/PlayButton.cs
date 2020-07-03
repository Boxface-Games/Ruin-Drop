using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    //Setting a Text Variable for Highscore
    public Text highscoreText;

    void Start()
    {
        //Obtaining the 'Highscore data from the player Preferences and displaying it
        highscoreText.text = "" + PlayerPrefs.GetInt("Highscore");
    }
   public void PlayButt()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
