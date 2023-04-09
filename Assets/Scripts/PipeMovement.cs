using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speedMod = 5.0f;
    bool scoreAdded = false;
    private ScoreTracker scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Canvas").GetComponent<ScoreTracker>();
    }


    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.z < 1.0f && !scoreAdded){
            scoreText.addScore();
            scoreAdded = true;
        }
        this.gameObject.transform.Translate(-1.0f * speedMod * Vector3.forward * Time.deltaTime);
        if (this.gameObject.transform.position.z < -3.0f){
            Destroy(this.gameObject);
        }
    }
}
