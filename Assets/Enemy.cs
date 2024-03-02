using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Bird");
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
        RotateMenacingly();
    }
    void MoveTowardsPlayer()
    {
        Vector3 targetPosition = player.transform.position;
        targetPosition.x -= 2; // Adjust this value to change how far to the left of the player the enemy will target
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();
        // If player is to the right of the enemy, just move left
        if (player.transform.position.x > transform.position.x)
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
        }
        else
        {
            transform.position += speed * Time.deltaTime * direction;
        }
    }
    void RotateMenacingly()
    {
        transform.Rotate(0, 0, 1);
    }
}
