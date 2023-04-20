using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speedMod = 5.0f;
    public string status;
    private ScoreTracker scoreText;
    private GameObject spacePipe;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Canvas").GetComponent<ScoreTracker>();

        spacePipe = this.gameObject.transform.GetChild(2).gameObject;

        float percentage = Random.value;
        if (percentage > 0.5)
        {
            status = "normal";
        }
        else if (percentage < 0.5 && percentage > 0.3)
        {
            status = "reward";
        }
        else if (percentage < 0.3)
        {
            status = "penalty";
        }

        if (status == "reward")
        {
            spacePipe.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (status == "penalty")
        {
            spacePipe.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(-1.0f * speedMod * Vector3.forward * Time.deltaTime);
        if (this.gameObject.transform.position.z < -4.0f)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, Random.Range(-8.0f, -3.0f), this.gameObject.transform.position.z + 48);
            scoreText.setScoreAdded(false);
        }
    }
}
