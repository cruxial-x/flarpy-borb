using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }
    void MoveTowardsPlayer()
    {
        GameObject player = GameObject.Find("Bird");
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        transform.position += speed * Time.deltaTime * direction;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
