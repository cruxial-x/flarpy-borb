using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float delay = 3f;
    public float minHeight;
    public float maxHeight;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DelayedStart", delay);
    }

    void DelayedStart()
    {
        InvokeRepeating("SpawnPipe", 0, spawnRate);
    }

    void Update()
    {

    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minHeight, maxHeight);
        Vector2 spawnPosition = new Vector2(transform.position.x, randomY);
        pipePrefab.tag = "Pipe";
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
}
