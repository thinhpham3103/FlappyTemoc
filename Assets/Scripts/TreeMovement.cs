using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMovement : MonoBehaviour
{
    public float speedMod = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(-1.0f * speedMod * Vector3.forward * Time.deltaTime);
        if (this.gameObject.transform.position.z < -4.0f)
        {
            this.gameObject.transform.position = new Vector3(0, 0, this.gameObject.transform.position.z + 48);
        }
    }
}
