using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float interval;

    IEnumerator spawn()
    {
        for (;;)
        {   
            Instantiate(pipePrefab,new Vector3(-3,Random.Range(-8.0f,-3.0f),10),Quaternion.identity);
            Instantiate(pipePrefab,new Vector3(0,Random.Range(-8.0f,-3.0f),10),Quaternion.identity);
            Instantiate(pipePrefab,new Vector3(3,Random.Range(-8.0f,-3.0f),10),Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
