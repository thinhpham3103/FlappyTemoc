using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour 
{
    public GameObject yourScore;
    public GameObject highScore;

    void Start()
    {
        int temp = 0;
        if(PlayerPrefs.HasKey("Score"))
        {
            yourScore.GetComponent<TextMeshProUGUI>().text = yourScore.GetComponent<TextMeshProUGUI>().text + "\n" + PlayerPrefs.GetInt("Score");

            if (PlayerPrefs.HasKey("HighScore"))
            {
                if(PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
                {
                    highScore.GetComponent<TextMeshProUGUI>().text = highScore.GetComponent<TextMeshProUGUI>().text + "\n" + PlayerPrefs.GetInt("Score");
                    temp = PlayerPrefs.GetInt("Score");
                }
                else
                {
                    highScore.GetComponent<TextMeshProUGUI>().text = highScore.GetComponent<TextMeshProUGUI>().text + "\n" + PlayerPrefs.GetInt("HighScore");
                    temp = PlayerPrefs.GetInt("HighScore");
                }
            }
            else
            {
                highScore.GetComponent<TextMeshProUGUI>().text = highScore.GetComponent<TextMeshProUGUI>().text + "\n" + PlayerPrefs.GetInt("Score");
                temp = PlayerPrefs.GetInt("Score");
            }
        }
        else
        {
            yourScore.GetComponent<TextMeshProUGUI>().text = yourScore.GetComponent<TextMeshProUGUI>().text + "\n" + 0;
            highScore.GetComponent<TextMeshProUGUI>().text = highScore.GetComponent<TextMeshProUGUI>().text + "\n" + 0;
        }
        PlayerPrefs.SetInt("HighScore", temp);
    }

    public void play() 
    {
        SceneManager.LoadScene("GameScene",LoadSceneMode.Single); // loads next scene (play)
    }
    
}
