using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject cloudPrefab;
    public float spawnRate = 2f;
    public float delay = 3f;

    public float cloudOffset = 2f;
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
        InvokeRepeating("SpawnCloud", 0, spawnRate * 1.5f);
    }

    void Update()
    {

    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minHeight, maxHeight);
        Vector2 spawnPosition = new Vector2(transform.position.x, randomY);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity);
    }
    void SpawnCloud()
    {
        float randomY = Random.Range(minHeight, maxHeight + cloudOffset);
        Vector2 spawnPosition = new(transform.position.x, randomY);
        GameObject newCloud = Instantiate(cloudPrefab, spawnPosition, Quaternion.identity);
        Collider2D cloudCollider = newCloud.GetComponent<Collider2D>();
        Collider2D playerCollider = GameObject.Find("Bird").GetComponent<Collider2D>();
        if (cloudCollider != null && playerCollider != null)
        {
            Physics2D.IgnoreCollision(playerCollider, cloudCollider);
        }
    }
}
