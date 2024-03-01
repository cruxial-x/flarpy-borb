using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("wtf");
        if(collision.gameObject.tag == "Pipe")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "ScoreZone")
        {
            Destroy(collision.gameObject);
        }
    }
}
