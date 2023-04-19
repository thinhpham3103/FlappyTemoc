using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentSpawn : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject treePrefab;
    public float interval;
    public float pipeOffset, treeOffset;
    public float start;

    private int numPipeRows = 4;

    //IEnumerator spawn()
    //{
    /**        Instantiate(pipePrefab, new Vector3(-3, Random.Range(-8.0f, -3.0f), start), Quaternion.identity);
            Instantiate(pipePrefab, new Vector3(0, Random.Range(-8.0f, -3.0f), start), Quaternion.identity);
            Instantiate(pipePrefab, new Vector3(3, Random.Range(-8.0f, -3.0f), start), Quaternion.identity);
            Instantiate(pipePrefab, new Vector3(-3, Random.Range(-8.0f, -3.0f), start + offset), Quaternion.identity);
            Instantiate(pipePrefab, new Vector3(0, Random.Range(-8.0f, -3.0f), start + offset), Quaternion.identity);
            Instantiate(pipePrefab, new Vector3(3, Random.Range(-8.0f, -3.0f), start + offset), Quaternion.identity);
            Instantiate(treePrefab, new Vector3(0, 0, start), Quaternion.identity);
            Instantiate(treePrefab, new Vector3(0, 0, start + offset/2), Quaternion.identity);
            Instantiate(treePrefab, new Vector3(0, 0, start + offset), Quaternion.identity);
            yield return new WaitForSeconds(interval);**/
    //}

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i < numPipeRows; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                PipeSpawn(-3 + (j * 3), start + i * pipeOffset);
            }
        }

        for(int i = 0; i < numPipeRows * 2; i++)
        {
            TreeSpawn(start + i * treeOffset);  
        }
    }

    void PipeSpawn(float x, float z)
    {
        Instantiate(pipePrefab, new Vector3(x, Random.Range(-8.0f, -3.0f), z), Quaternion.identity);
    }

    void TreeSpawn(float z)
    {
        Instantiate(treePrefab, new Vector3(0, 0, z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
