using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    int score = 0;
    bool scoreAdded = false;
    public TextMeshProUGUI scoretext;

    public void addScore()
    {
        score++;
        scoretext.text = "Score: " + score.ToString();
    }

    public void resetScore()
    {
        score = 0;
        scoretext.text = "Score: " + score.ToString();
    }

    public void subtractScore()
    {
        score -= 2;
        scoretext.text = "Score: " + score.ToString();
    }

    public void addMoretoScore()
    {
        score += 2;
        scoretext.text = "Score: " + score.ToString();
    }

    public int getScore()
    {
        return score;
    }

    public bool getScoreAdded()
    {
        return scoreAdded;
    }

    public void setScoreAdded(bool added)
    {
        scoreAdded = added;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoretext.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
