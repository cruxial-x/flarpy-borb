using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenInvisible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy the object when it becomes invisible
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
