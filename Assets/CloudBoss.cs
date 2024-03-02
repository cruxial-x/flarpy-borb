using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBoss : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject evilCloud;
    public float zigzagSpeed = 1.0f;
    public float zigzagMagnitude = 1.0f;
    private float zigzagTime = 0.0f;
    public float evilCloudSpawnRate = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEvilCloud", 0, evilCloudSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        ZigZagTowardsBird();
    }

    void ZigZagTowardsBird()
    {
        GameObject player = GameObject.Find("Bird");
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();

        // Add a zigzag pattern to the y-component of the direction vector
        direction.y += Mathf.Sin(zigzagTime * zigzagSpeed) * zigzagMagnitude;

        transform.position += speed * Time.deltaTime * direction;

        // Update the zigzag time
        zigzagTime += Time.deltaTime;
    }
    void SpawnEvilCloud()
    {
        Instantiate(evilCloud, transform.position, Quaternion.identity);
    }
}
