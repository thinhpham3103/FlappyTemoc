using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI scoretext;

    public void addScore(){
        score++;
        scoretext.text = "Score: " + Mathf.Floor(score/3).ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
