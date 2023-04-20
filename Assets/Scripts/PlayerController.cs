using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody RB;

    int currentLane = 1;
    float laneVal = 3.0f;
    float[] lanePos;
    float speed = 10.0f;
    bool moving = false;
    float startTime;
    public ScoreTracker score;
    public float ySpeed;
    public float fallSpeed;

    void OnEnable() //On startup commands
    {
        EventManager.moveLeft += MoveLeft;
        EventManager.moveRight += MoveRight;
        EventManager.jump += Jump;
    }

    void OnDisable()
    {
        EventManager.moveLeft -= MoveLeft;
        EventManager.moveRight -= MoveRight;
        EventManager.jump -= Jump;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        lanePos = new float[] {-laneVal,0,laneVal};
        score = GameObject.Find("Canvas").GetComponent<ScoreTracker>();
    }

    // Update is called once per frame
    void Update()
    {

        if (moving)
        {
            float distCovered = (Time.time - startTime) * speed;
            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / laneVal;
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(this.gameObject.transform.position,
                                                new Vector3(lanePos[currentLane],
                                                this.gameObject.transform.position.y,
                                                this.gameObject.transform.position.z),
                                                fractionOfJourney);

            if (Mathf.Approximately(fractionOfJourney,1.0f))
            {
                moving = false;
            }
        }
    }

    void MoveLeft()
    {
        if (currentLane != 0)
        {
            startTime = Time.time;
            moving = true;
            // gameObject.transform.Translate(-laneVal,0,0);
            currentLane--;
        }
    }

    void MoveRight()
    {
        if (currentLane != 2)
        {
            startTime = Time.time;
            moving = true;
            //gameObject.transform.Translate(laneVal,0,0);
            currentLane++;
        }
    }

    void Jump()
    {
        RB.AddForce(new Vector3(0,12,0),ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            Debug.Log("Touched obstacle");
            PlayerPrefs.SetInt("Score", score.getScore());
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
        else if (other.gameObject.tag == "space")
        {
            if (!score.getScoreAdded())
            {
                if (other.gameObject.transform.parent.gameObject.GetComponent<PipeMovement>().status == "normal")
                {
                    Debug.Log("Score added");
                    score.addScore();
                }
                else if (other.gameObject.transform.parent.gameObject.GetComponent<PipeMovement>().status == "reward")
                {
                    Debug.Log("Score added+");
                    score.addMoretoScore();
                }
                else if (other.gameObject.transform.parent.gameObject.GetComponent<PipeMovement>().status == "penalty")
                {
                    Debug.Log("Score subtracted");
                    score.subtractScore();
                }

                score.setScoreAdded(true);
            }
        }   

    }


}
