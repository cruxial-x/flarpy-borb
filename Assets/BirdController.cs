using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameController gameController;

    public Text scoreText;
    private int score = 0;

    public float flapForce = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * flapForce;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Pipe")
        {
            Destroy(gameObject);
            gameController.GameOver();
        }
        if(collision.gameObject.tag == "ScoreZone")
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            IncrementScore();
            Debug.Log("Score: " + score);
        }
    }
        // Call this method when the bird clears a pipe
    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }
        // Update the score text UI
    private void UpdateScoreText()
    {
        scoreText.text = "  Score: " + score;
    }
}
