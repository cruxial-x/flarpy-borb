using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudBoss : MonoBehaviour
{
    public float speed = 1.0f;
    public GameObject evilCloud;
    public int hitPoints = 3;
    public float zigzagSpeed = 1.0f;
    public float zigzagMagnitude = 1.0f;
    private float zigzagTime = 0.0f;
    public float evilCloudSpawnRate = 1.0f;
    private BirdController bird;
    public GameObject healthPrefab; 
    private GameObject healthBar;
    private List<GameObject> healthCircles = new List<GameObject>(); // List to store the health circles

    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.Find("Bird").GetComponent<BirdController>();
        healthBar = GameObject.Find("Health");
        Transform healthCircleParent = healthBar.transform;
        InvokeRepeating("SpawnEvilCloud", 0, evilCloudSpawnRate);
        for (int i = 0; i < hitPoints; i++)
        {
            GameObject healthCircle = Instantiate(healthPrefab, healthCircleParent);
            healthCircles.Add(healthCircle);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ZigZagTowardsBird();
        if(hitPoints <= 0)
        {
            bird.IncrementScore(3);
            bird.ResetCloudHitCount(); // Reset the cloud hit count in the bird
            Destroy(gameObject);
        }
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            Debug.Log("I'm hit!");
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.Play();
            }
            else
            {
                Debug.Log("No AudioSource found on this GameObject.");
            }
        hitPoints--;
        // Remove a health circle from the screen
        if (healthCircles.Count > 0)
        {
            Destroy(healthCircles[healthCircles.Count - 1]);
            healthCircles.RemoveAt(healthCircles.Count - 1);
        }
        Destroy(collision.gameObject);
        }
    }
    void SpawnEvilCloud()
    {
        Instantiate(evilCloud, transform.position, Quaternion.identity);
    }
}
